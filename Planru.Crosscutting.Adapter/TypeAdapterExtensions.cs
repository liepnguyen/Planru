using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Adapter
{
    public static class TypeAdapterExtensions
    {
        public static T AdaptTo<T>(this object source)
        {
            return (T)new object();
        }
    }
}
