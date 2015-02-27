using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dispatcher;
using System.Reflection;
using System.IO;

namespace Planru.Core.WebAPI.Resolvers
{
    public class AssembliesResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var files = Directory.GetFiles(appPath + "\\Modules", "Planru.Modules.*.dll", SearchOption.AllDirectories);
            var pluginAssemblies = files.Select(Assembly.LoadFile).ToList();
            assemblies.AddRange(pluginAssemblies);
            return assemblies;
        } 
    }
}