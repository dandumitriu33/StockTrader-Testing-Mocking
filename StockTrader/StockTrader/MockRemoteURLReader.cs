using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_trader_app_DI_csharp.StockTrader
{
    class MockRemoteURLReader : IRemoteURLReader
    {
        public string ReadFromUrl(string endpoint)
        {
            throw new NotImplementedException();
        }
    }
}
