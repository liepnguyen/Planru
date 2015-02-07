using NUnit.Framework;
using Planru.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Tests.Configuration
{
    [TestFixture]
    public class ConfigurationTest
    {
        [SetUp]
        public void Init()
        { 
        
        }

        [Test]
        public void TestConfiguration()
        {
            PlanruSection planruConfigSection =
                ConfigurationManager.GetSection("Planru") as PlanruSection;
        }
    }
}
