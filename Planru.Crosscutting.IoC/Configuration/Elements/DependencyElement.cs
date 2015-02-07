using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Planru.Crosscutting.IoC.Configuration.Elements
{
    public class DependencyElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("resolve", IsRequired = true)]
        public string Resolve
        {
            get { return (string)this["resolve"]; }
            set { this["resolve"] = value; }
        }

        [ConfigurationProperty("scope", IsRequired = true)]
        public string Scope
        {
            get { return (string)this["scope"]; }
            set { this["scope"] = value; }
        }
    }
}
