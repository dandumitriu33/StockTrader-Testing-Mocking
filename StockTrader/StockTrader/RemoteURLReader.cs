using System.Net;

namespace stockTrader
{
    public class RemoteURLReader
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