using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Adapter
{
    public static class TypeAdapterExtensions
    {
        public static T Adapt<T>(this object source)
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<T>(source);
        }
    }
}
