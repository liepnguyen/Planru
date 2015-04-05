using MongoDB.Driver;
using Planru.Core.Module.WebAPI;
using Planru.Core.Persistence.MongoDB;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.Adapter.Automapper;
using Planru.Crosscutting.IoC;
using Planru.Crosscutting.IoC.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planru.DistributedServices.WebAPI
{
    public class IoCConfig
    {
        private static Lazy<IContainer> _container = new Lazy<IContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IContainer GetConfiguredContainer()
        {
            return _container.Value;
        }

        public static void RegisterTypes(IContainer container)
        {
            TypeAdapterFactory.SetCurrent(new AutomapperSingletonTypeAdapterFactory());

            var dbContext = new MongoDbContext(
                "mongodb://liepnguyen:abcd1234@ds055680.mongolab.com:55680/planru_system",
                "planru_system");

            container.RegisterInstance<IMongoDbContext>(dbContext);
        }
    }
}