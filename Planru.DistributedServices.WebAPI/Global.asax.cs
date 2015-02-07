using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using System.Web.Http.Dispatcher;
using Planru.Core.WebAPI.Resolvers;
using Planru.Core.Plugin.WebAPI;
using System.Reflection;
using System.IO;

namespace Planru.DistributedServices.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver), new AssembliesResolver());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            PluginConfig.ConfigPlugins();
        }
    }
}
