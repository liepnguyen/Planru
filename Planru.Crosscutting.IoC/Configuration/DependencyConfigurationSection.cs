using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Planru.Crosscutting.IoC.Configuration.Elements;

namespace Planru.Crosscutting.IoC.Configuration
{
    public class DependencyConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("dependencies", Options = ConfigurationPropertyOptions.IsRequired)]
        public DependencyElementCollection Dependencies
        {
            get
            {
                return (DependencyElementCollection)base["dependencies"];
            }
        }
    }
}
