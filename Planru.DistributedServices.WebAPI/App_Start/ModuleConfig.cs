using Planru.Core.Module.WebAPI;
using Planru.Crosscutting.Adapter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Planru.DistributedServices.WebAPI
{
    public class ModuleConfig
    {
        public static void ConfigModules()
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var files = Directory.GetFiles(appPath + "\\Modules", "Planru.Modules.*.WebAPI.dll", SearchOption.AllDirectories);
            var moduleAssemblies = files.Select(Assembly.LoadFile).ToList();

            var configTypes = moduleAssemblies
                            .SelectMany(p => p.GetTypes())
                            .Where(t => t.GetInterfaces().Any(i => i == typeof(IWebApiConfig)));

            foreach (var configType in configTypes)
            {
                var config = (IWebApiConfig)Activator.CreateInstance(configType);
                var container = IoCConfig.GetConfiguredContainer();
                var typeAdapter = TypeAdapterFactory.CreateAdapter();

                config.RegisterTypes(container);
                config.CreateMappings(typeAdapter);
            }
        }
    }
}