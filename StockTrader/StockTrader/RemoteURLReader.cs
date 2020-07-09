using stock_trader_app_DI_csharp.StockTrader;
using System.Net;

namespace stockTrader
{
    public class RemoteURLReader : IRemoteURLReader
    {
        private RemoteURLReader _instance;

        public RemoteURLReader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RemoteURLReader();
                }
                return _instance;
            }
        }
        public string ReadFromUrl(string endpoint) {
            using(var client = new WebClient()) {
                return client.DownloadString(endpoint);
            }
        }
    }
}