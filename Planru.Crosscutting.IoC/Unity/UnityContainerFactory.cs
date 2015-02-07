using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.IoC.Unity
{
    public class UnityContainerFactory : IContainerFactory
    {
        public IContainer Create()
        {
            return new UnityContainer();
        }
    }
}
