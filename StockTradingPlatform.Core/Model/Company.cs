namespace StockTradingPlatform.Core.Model
{
    public class Company
    {
        /// <summary>
        ///     Model representing a company
        /// </summary>
        /// <param name="symbol"> The string value that represents the company</param>
        public Company(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; set; }

        // TODO fluent validation
    }
}