using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Planru.Crosscutting.IoC.Configuration.Elements
{
    [ConfigurationCollection(typeof(DependencyElement), AddItemName = "dependency")]
    public class DependencyElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DependencyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((DependencyElement)element).Type;
        }
    }
}
