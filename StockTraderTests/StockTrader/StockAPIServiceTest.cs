using NUnit.Framework;
using Autofac.Extras.Moq;
using stock_trader_app_DI_csharp.StockTrader;

namespace stockTrader
{
    public class StockAPIServiceTest
    {
        [Test] // everything works
        public void TestGetPriceNormalValues()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var mockResponse = "{\n\"symbol\" : \"TEST\",\n\"price\" : 383.08000000,\n\"volume\" : 18086123\n}";
                mock.Mock<IRemoteURLReader>()
                    .Setup(x => x.ReadFromUrl($"https://financialmodelingprep.com/api/v3/stock/real-time-price/TEST?apikey=demo"))
                    .Returns(mockResponse);

                var cls = mock.Create<StockAPIService>();
                var expected = 383.08000000;

                var actual = cls.GetPrice("TEST");

                Assert.AreEqual(expected, actual);
                Assert.AreNotEqual(384.0800, actual);
            }
        }

        [Test] // readFromURL threw an exception
        public void TestGetPriceServerDown()
        {
        }

        [Test] // readFromURL returned wrong JSON
        public void TestGetPriceMalformedResponse() 
        {
        }
    }
}