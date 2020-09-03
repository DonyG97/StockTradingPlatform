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

        public IEnumerable<Order> GetIncompleteOrders()
        {
            return _orderContext.GetOrders().Where(x => x.Status != OrderStatus.Complete);
        }

        public IEnumerable<Order> GetCompleteOrders()
        {
            return _orderContext.GetOrders().Where(x => x.Status == OrderStatus.Complete);
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
            if (ProcessShareQuantities(newOrder, company)) return;

            _orderContext.UpdateOrder(newOrder);
        }

        private static bool ProcessShareQuantities(Order newOrder, Company company)
        {
            if (company.RemainingNumberOfShares == 0) return true;

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

            return false;
        }

        private void ProcessExistingOrders(Order order, Company company)
        {
            var companyOrders = _orderContext.GetOrders()
                .Where(x => string.Equals(x.CompanySymbol, order.CompanySymbol));
            var unprocessedOrders = companyOrders.Where(x => x.Status == OrderStatus.Processing);
            var ordersWithinPriceRange = unprocessedOrders.Where(x => x.MinPrice >= order.MinPrice && x.MaxPrice <= order.MaxPrice);

            // We need to check the orders in created time ascending order
            foreach (var existingOrder in ordersWithinPriceRange.OrderBy(x => x.Created))
            {
                if (ProcessShareQuantities(existingOrder, company)) return;

                _orderContext.UpdateOrder(existingOrder);
            }
        }
    }
}