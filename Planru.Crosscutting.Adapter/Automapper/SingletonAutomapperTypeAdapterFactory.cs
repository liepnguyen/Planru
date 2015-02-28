using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Adapter.Automapper
{
    public class SingletonAutomapperTypeAdapterFactory : ITypeAdapterFactory
    {
        private static Lazy<ITypeAdapter> _typeAdapter = new Lazy<ITypeAdapter>(() =>
        {
            var typeAdapter = new AutomapperTypeAdapter();
            return typeAdapter;
        });

        public ITypeAdapter Create()
        {
            return _typeAdapter.Value;
        }
    }
}
