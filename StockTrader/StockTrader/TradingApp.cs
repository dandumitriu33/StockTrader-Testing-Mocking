using Autofac;
using stock_trader_app_DI_csharp.StockTrader;
using System;

namespace stockTrader
{

    internal class TradingApp : ITradingApp
    {
        private readonly ITrader _trader;
        public static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }

        public TradingApp(ITrader trader)
        {
            _trader = trader;
        }

        public void Start()
        {
            Console.WriteLine("Enter a stock symbol (for example aapl):");
            string symbol = Console.ReadLine();
            Console.WriteLine("Enter the maximum price you are willing to pay: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Please enter a number.");
            }

            try
            {
                bool purchased = _trader.Buy(symbol, price);
                if (purchased)
                {
                    Logger.Instance.Log("Purchased stock!");
                }
                else
                {
                    Logger.Instance.Log("Couldn't buy the stock at that price.");
                }
            }
            catch (Exception e)
            {
                Logger.Instance.Log("There was an error while attempting to buy the stock: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}