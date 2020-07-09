using System;

namespace stockTrader
{

  internal class TradingApp
  {
    public static void Main(string[] args)
    {
		Trader traderDI = new Trader();
	    TradingApp app = new TradingApp(traderDI);
	    app.Start();
    }
		private readonly Trader _trader;

        public TradingApp(Trader trader)
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
	    
	    try {
		    bool purchased = _trader.Buy(symbol, price);
		    if (purchased) {
			    Logger.Instance.Log("Purchased stock!");
		    }
		    else {
			    Logger.Instance.Log("Couldn't buy the stock at that price.");
		    }
	    } catch (Exception e) {
		    Logger.Instance.Log("There was an error while attempting to buy the stock: " + e.Message);
	    }
        Console.ReadLine();
    }
  }
}