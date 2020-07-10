using NUnit.Framework;
using Autofac.Extras.Moq;
using stock_trader_app_DI_csharp.StockTrader;
using System;
using NSubstitute.ExceptionExtensions;

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
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRemoteURLReader>()
                    .Setup(x => x.ReadFromUrl($"https://financialmodelingprep.com/api/v3/stock/real-time-price/TEST?apikey=demo"))
                    .Throws(new ApplicationException("Error"));

                Assert.Throws<ApplicationException>(() => mock.Create<StockAPIService>().GetPrice("TEST"));
            }
        }

        [Test] // readFromURL returned wrong JSON
        public void TestGetPriceMalformedResponse() 
        {
            // will change the JSON data to a different field name for price, 
            // so that the StockAPIService can't read it and consider it null
            using (var mock = AutoMock.GetLoose())
            {
                var mockResponse = "{\n\"symbol\" : \"TEST\",\n\"priceZZZZ\" : 383.08000000,\n\"volume\" : 18086123\n}";
                mock.Mock<IRemoteURLReader>()
                    .Setup(x => x.ReadFromUrl($"https://financialmodelingprep.com/api/v3/stock/real-time-price/TEST?apikey=demo"))
                    .Returns(mockResponse);

                Assert.Throws<NullReferenceException>(() => mock.Create<StockAPIService>().GetPrice("TEST"));
            }
        }
    }
}