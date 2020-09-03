using System.Collections.Generic;
using StockTradingPlatform.Core.DataAccess;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.Core.CoreLogic
{
    public class OrderService
    {
        private readonly OrderContext _orderContext;

        public OrderService(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderContext.GetOrders();
        }

        public Order GetOrder(string symbol)
        {
            return _orderContext.GetOrder(symbol);
        }

        // TODO: Decide whether this should return the company. Nothing get's set on the company so the object doesn't change but it's probably a good idea
        public void AddOrder(Order order)
        {
            _orderContext.AddOrder(order);
        }
    }
}