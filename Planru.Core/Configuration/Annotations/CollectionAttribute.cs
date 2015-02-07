using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Configuration.Annotations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionAttribute : Attribute
    {
        public string Name { get; set; }
        public CollectionAttribute(string name)
        {
            this.Name = name;
        }
    }
}
