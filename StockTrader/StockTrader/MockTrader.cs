using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_trader_app_DI_csharp.StockTrader
{
    class MockTrader : ITrader
    {
        public bool Buy(string symbol, double bid)
        {
            double price = 400.25;
            bool result;
            if (price <= bid)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
