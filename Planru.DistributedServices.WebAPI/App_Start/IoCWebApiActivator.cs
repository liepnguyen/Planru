using Planru.Crosscutting.IoC.Unity.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Planru.DistributedServices.WebAPI.IoCWebApiActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Planru.DistributedServices.WebAPI.IoCWebApiActivator), "Shutdown")]
namespace Planru.DistributedServices.WebAPI
{
    public class IoCWebApiActivator
    {
        public static void Start()
        {
            var resolver = new UnityDependencyResolver(IoCConfig.GetConfiguredContainer());
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = IoCConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}