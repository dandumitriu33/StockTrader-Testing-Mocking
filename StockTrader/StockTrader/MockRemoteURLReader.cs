using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_trader_app_DI_csharp.StockTrader
{
    class MockRemoteURLReader : IRemoteURLReader
    {
        /// <summary>
        /// Mock method that doesn't actually contact the API to obtain info but has hardcoded info.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public string ReadFromUrl(string endpoint)
        {
            var mockResponse = "{\n\"symbol\" : \"AAPL\",\n\"price\" : 383.08000000,\n\"volume\" : 18086123\n}";
            return mockResponse;
        }
    }
}
