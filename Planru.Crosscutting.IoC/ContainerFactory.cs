using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.IoC
{
    public static class ContainerFactory
    {
        static IContainerFactory _containerFactory = null;

        public static void SetCurrent(IContainerFactory containerFactory)
        {
            _containerFactory = containerFactory;
        }

        public static IContainer CreateContainer()
        {
            return (_containerFactory != null) ? _containerFactory.Create() : null;
        }

    }
}
