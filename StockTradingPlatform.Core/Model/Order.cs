using System;

namespace StockTradingPlatform.Core.Model
{
    /// <summary>
    ///     The model representing the order concept
    /// </summary>
    public class Order
    {
        public Order(string companySymbol, int min, int max, int quantity, OrderType type)
        {
            CompanySymbol = companySymbol;
            Min = min;
            Max = max;
            Quantity = quantity;
            Type = type;
        }

        public Guid Id { get; set; }

        public string CompanySymbol { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public int Quantity { get; set; }

        public OrderType Type { get; set; }

        public OrderStatus Status { get; set; }
    }

    /// <summary>
    ///     Enum representing the different status' of an order
    /// </summary>
    public enum OrderStatus
    {
        Processing,
        Complete
    }

    /// <summary>
    ///     Enum representing the types of order
    /// </summary>
    // TODO: Find out if there is a preference for the default type
    public enum OrderType
    {
        Buy,
        Sell
    }

    // TODO: Fluent validation
}