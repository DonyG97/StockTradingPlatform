using System;
using System.Collections.Generic;
using System.Linq;
using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.Core.DataAccess
{
    public class OrderContext
    {
        private readonly List<Order> _orders = new List<Order>();

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        public Order GetOrder(string symbol)
        {
            // TODO: Error handling if the symbol does not match an existing order

            // TODO: Think about whether this needs to be case sensitive
            return _orders.First(x =>
                string.Equals(x.CompanySymbol, symbol, StringComparison.InvariantCultureIgnoreCase));
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }
    }
}