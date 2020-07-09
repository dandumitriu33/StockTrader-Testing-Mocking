using stockTrader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockTrader
{
    public class Application : IApplication
    {
        ITradingApp _tradingApp;
        public Application(ITradingApp tradingApp)
        {
            _tradingApp = tradingApp;
        }

        public void Run()
        {
            _tradingApp.Start();
        }
    }
}
