using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.Adapter.Automapper;
using Planru.Plugins.Directory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Tests
{
    
    [TestClass]
    public class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void InitializeAssemblies(TestContext context)
        {
            Assembly.Load("Planru.Plugins.Directory");
            ITypeAdapterFactory adapterfactory = new AutomapperTypeAdapterFactory();
            TypeAdapterFactory.SetCurrent(adapterfactory);
        }
    }

}
