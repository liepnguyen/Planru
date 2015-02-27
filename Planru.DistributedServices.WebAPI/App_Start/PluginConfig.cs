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
    public class PluginConfig
    {
        public static void ConfigPlugins()
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var files = Directory.GetFiles(appPath + "\\Plugins", "Planru.Plugins.*.WebAPI.dll", SearchOption.AllDirectories);
            var pluginAssemblies = files.Select(Assembly.LoadFile).ToList();

            var configTypes = pluginAssemblies
                            .SelectMany(p => p.GetTypes())
                            .Where(t => t.GetInterfaces().Any(i => i == typeof(IWebApiConfig)));

            foreach (var configType in configTypes)
            {
                var config = (IWebApiConfig)Activator.CreateInstance(configType);
                var container = IoCConfig.GetConfiguredContainer();
                var typeAdapter = container.Resolve<ITypeAdapter>();

                config.RegisterTypes(container);
                config.CreateMappings(typeAdapter);
            }
        }
    }
}