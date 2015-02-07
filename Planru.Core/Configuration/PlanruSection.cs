using Planru.Core.Configuration.Elements;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Configuration
{
    public class PlanruSection : ConfigurationSection
    {
        [ConfigurationProperty("modules", Options = ConfigurationPropertyOptions.IsRequired)]
        public ModuleElementCollection Modules
        {
            get
            {
                return (ModuleElementCollection)this["modules"];
            }
        }

        
    }
}
