using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_trader_app_DI_csharp.StockTrader
{
    interface IStockAPIService
    {
        double GetPrice(string symbol);
        bool Buy(string symbol);
    }
}
