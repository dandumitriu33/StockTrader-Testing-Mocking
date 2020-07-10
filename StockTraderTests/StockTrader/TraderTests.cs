using System;
using Autofac.Extras.Moq;
using NUnit.Framework;
using stock_trader_app_DI_csharp.StockTrader;

namespace stockTrader
{
    [TestFixture]
    public class TraderTests
    {
        
        [Test] // Bid was lower than price, Buy() should return false.
        public void TestBidLowerThanPrice()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IStockAPIService>()
                    .Setup(x => x.GetPrice("AAPL"))
                    .Returns(350.23);

                var cls = mock.Create<Trader>();
                var expected = false;

                var actual = cls.Buy("AAPL", 200.0);

                Assert.AreEqual(expected, actual);
            }
        }

        [Test] // bid was equal or higher than price, Buy() should return true.
        public void TestBidHigherThanPrice()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IStockAPIService>()
                    .Setup(x => x.GetPrice("AAPL"))
                    .Returns(350.23);

                var cls = mock.Create<Trader>();
                var expected = true;

                var actualEqual = cls.Buy("AAPL", 350.23);
                var actualHigher = cls.Buy("AAPL", 400.25);

                Assert.AreEqual(expected, actualEqual);
                Assert.AreEqual(expected, actualHigher);
            }
        }
    }
}