using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Adapter.Automapper
{
    public class AutomapperSingletonTypeAdapterFactory : ITypeAdapterFactory
    {
        private static Lazy<ITypeAdapter> _typeAdapter = new Lazy<ITypeAdapter>(() =>
        {
            var typeAdapter = new AutomapperTypeAdapter();
            Initialize(typeAdapter);
            return typeAdapter;
        });

        private static void Initialize(ITypeAdapter typeAdapter)
        { 
            // TODO:
        }

        public ITypeAdapter Create()
        {
            return _typeAdapter.Value;
        }
    }
}
