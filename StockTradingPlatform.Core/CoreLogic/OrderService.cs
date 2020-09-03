using System;
using System.Collections.Generic;
using System.Linq;
using StockTradingPlatform.Core.DataAccess;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.Core.CoreLogic
{
    public class OrderService
    {
        private readonly CompanyContext _companyContext;
        private readonly OrderContext _orderContext;

        public OrderService(OrderContext orderContext, CompanyContext companyContext)
        {
            _orderContext = orderContext;
            _companyContext = companyContext;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderContext.GetOrders();
        }

        public Order GetOrder(Guid id)
        {
            return _orderContext.GetOrder(id);
        }


        public Order AddOrder(Order order)
        {
            // TODO: This error message should be changes as its somewhat a security flaw. It could be abused to find out which companies are in the system
            var company = _companyContext.GetCompany(order.CompanySymbol);
            if (company == null) throw new Exception("Cannot create orders for a company that does not exist");

            ProcessExistingOrders(order, company);

            var newOrder = _orderContext.AddOrder(order);

            ProcessNewOrder(newOrder, company);

            return newOrder;
        }

        private void ProcessNewOrder(Order newOrder, Company company)
        {
            if (company.RemainingNumberOfShares == 0) return;

            // If the company has enough shares remaining then fulfill the order
            if (company.RemainingNumberOfShares >= newOrder.AmountRemaining)
            {
                company.RemainingNumberOfShares -= newOrder.AmountRemaining;
                newOrder.AmountRemaining = 0;
            }
            else
            {
                newOrder.AmountRemaining -= company.RemainingNumberOfShares;
                company.RemainingNumberOfShares = 0;
            }

            _orderContext.UpdateOrder(newOrder);
        }

        private void ProcessExistingOrders(Order order, Company company)
        {
            var companyOrders = _orderContext.GetOrders()
                .Where(x => string.Equals(x.CompanySymbol, order.CompanySymbol));
            var unprocessedOrders = companyOrders.Where(x => x.Status == OrderStatus.Processing);
            var ordersWithinPriceRange = unprocessedOrders.Where(x => x.Min >= order.Min && x.Max <= order.Max);

            // We need to check the orders in created time ascending order
            foreach (var existingOrder in ordersWithinPriceRange.OrderBy(x => x.Created))
            {
                if (company.RemainingNumberOfShares == 0) return;

                // If the company has enough shares remaining then fulfill the order
                if (company.RemainingNumberOfShares >= existingOrder.AmountRemaining)
                {
                    company.RemainingNumberOfShares -= existingOrder.AmountRemaining;
                    existingOrder.AmountRemaining = 0;
                }
                else
                {
                    existingOrder.AmountRemaining -= company.RemainingNumberOfShares;
                    company.RemainingNumberOfShares = 0;
                }

                _orderContext.UpdateOrder(existingOrder);
            }
        }
    }
}