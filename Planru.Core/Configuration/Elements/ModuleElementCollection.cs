using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Planru.Core.Configuration.Elements
{
    [ConfigurationCollection(typeof(ModuleElement), AddItemName = "module")]
    public class ModuleElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ModuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((ModuleElement)element).Name;
        }
    }
}
