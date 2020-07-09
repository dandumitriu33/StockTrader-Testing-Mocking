using Autofac;
using stock_trader_app_DI_csharp.StockTrader;
using stockTrader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockTrader
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<TradingApp>().As<ITradingApp>();
            builder.RegisterType<Trader>().As<ITrader>();
            builder.RegisterType<StockAPIService>().As<IStockAPIService>();
            builder.RegisterType<RemoteURLReader>().As<IRemoteURLReader>();

            return builder.Build();
        }
    }
}
