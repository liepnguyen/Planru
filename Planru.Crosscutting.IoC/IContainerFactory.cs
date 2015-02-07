using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planru.Crosscutting.IoC
{
    public interface IContainerFactory
    {
        IContainer Create();
    }
}
