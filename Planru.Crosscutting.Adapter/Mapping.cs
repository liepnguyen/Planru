using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Adapter
{
    public class Mapping
    {
        public Type TSource { get; set; }
        public Type TTarget { get; set; }

        public Mapping(Type tSource, Type tTarget)
        {
            TSource = tSource;
            TTarget = tTarget;
        }
    }

    
}
