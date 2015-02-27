using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Planru.Crosscutting.IoC.Configuration.Elements;
using Planru.Crosscutting.IoC.Configuration;

namespace Planru.Core.Module.Configuration
{
    public abstract class PluginConfiguration : IPluginConfiguration
    {
        private DependencyConfigurationSection _dependencyConfigSection;
        public PluginConfiguration()
        {
            _dependencyConfigSection = ConfigurationManager
                .GetSection("dependencyConfigSection") as DependencyConfigurationSection;
        }

        public virtual void RegisterTypes(IContainer container)
        {
            foreach (DependencyElement dependencyElement in _dependencyConfigSection.Dependencies)
            {
                var from = Type.GetType(dependencyElement.Type);
                var to = Type.GetType(dependencyElement.Resolve);

                container.Register(from, to);
            }
        }

        public virtual void CreateMappings(ITypeAdapter typeAdapter)
        {
            throw new NotImplementedException();
        }
    }
}
