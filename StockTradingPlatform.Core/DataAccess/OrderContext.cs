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

        public Order GetOrder(Guid id)
        {
            // TODO: Error handling if the symbol does not match an existing order

            // TODO: Think about whether this needs to be case sensitive
            return _orders.FirstOrDefault(x => x.Id == id);
        }

        public Order AddOrder(Order order)
        {
            order.Id = Guid.NewGuid();
            order.Created = DateTime.UtcNow;
            _orders.Add(order);
            return order;
        }

        public Order UpdateOrder(Order orderToUpdate)
        {
            var foundOrderIndex = _orders.FindIndex(x => x.Id == orderToUpdate.Id);
            if (foundOrderIndex == -1) return null;

            _orders[foundOrderIndex] = orderToUpdate;
            return _orders[foundOrderIndex];
        }
    }
}