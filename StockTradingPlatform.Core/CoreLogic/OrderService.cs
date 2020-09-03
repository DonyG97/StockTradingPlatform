using System;
using System.Collections.Generic;
using StockTradingPlatform.Core.DataAccess;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.Core.CoreLogic
{
    public class OrderService
    {
        private readonly OrderContext _orderContext;
        private readonly CompanyContext _companyContext;

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
            if (_companyContext.GetCompany(order.CompanySymbol) == null)
            {
                // TODO: This error message should be changes as its somewhat a security flaw. It could be abused to find out which companies are in the system
                throw new Exception("Cannot create orders for a company that does not exist");
            }

            return _orderContext.AddOrder(order);
        }
    }
}