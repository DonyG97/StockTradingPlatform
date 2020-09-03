using System;

namespace StockTradingPlatform.Core.Model
{
    /// <summary>
    ///     The model representing the order concept
    /// </summary>
    public class Order
    {
        public Order(string companySymbol, decimal minPrice, decimal maxPrice, int quantity, OrderType type)
        {
            CompanySymbol = companySymbol;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            Quantity = quantity;
            Type = type;
            AmountRemaining = quantity;
        }

        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public string CompanySymbol { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public int Quantity { get; set; }

        public OrderType Type { get; set; }

        public int AmountRemaining { get; set; }

        public OrderStatus Status => AmountRemaining == 0 ? OrderStatus.Complete : OrderStatus.Processing;
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