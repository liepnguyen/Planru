using Planru.Crosscutting.IoC.Configuration.Elements;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.IoC.Configuration
{
    public class IoCConfigurator
    {
        public static void LoadConfig(IContainer container)
        {
            DependencyConfigurationSection dependencyConfigSection =
                ConfigurationManager.GetSection("planru.ioc") as DependencyConfigurationSection;

            if (dependencyConfigSection != null)
            {
                foreach (DependencyElement dependencyElement in dependencyConfigSection.Dependencies)
                {
                    var type = Type.GetType(dependencyElement.Type);
                    var resolve = Type.GetType(dependencyElement.Resolve);
                    if (string.IsNullOrEmpty(dependencyElement.Scope))
                        container.Register(type, resolve);
                    else if (dependencyElement.Scope.ToUpper() == "SINGLE-INSTANCE")
                        container.Register(type, resolve, LifeTimeOptions.ContainerControlledLifeTimeOption);
                }
            }
        }
    }
}
