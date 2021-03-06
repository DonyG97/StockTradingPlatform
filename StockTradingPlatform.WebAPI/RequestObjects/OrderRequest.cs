﻿using StockTradingPlatform.Core.Model;

namespace StockTradingPlatform.WebAPI
{
    public class OrderRequest
    {
        // While this is somewhat a duplicate of the Order model it means they cannot set the order status when posting new orders

        public string Symbol { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public int Quantity { get; set; }

        public OrderType OrderType { get; set; }
    }
}