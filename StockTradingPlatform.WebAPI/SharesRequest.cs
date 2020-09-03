using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTradingPlatform.WebAPI
{
    public class SharesRequest
    {
        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
