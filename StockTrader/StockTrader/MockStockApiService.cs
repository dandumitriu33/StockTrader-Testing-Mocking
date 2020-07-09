using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_trader_app_DI_csharp.StockTrader
{
    class MockStockAPIService : IStockAPIService
    {
        public double GetPrice(string symbol)
        {
            return 5000.34;
        }

        /// <summary>
        /// Buys a share of the given stock at the current price. Returns false if the purchase fails 
        /// </summary>
        public bool Buy(string symbol)
        {
            // Stub. No need to implement this.
            return true;
        }
    }

}
