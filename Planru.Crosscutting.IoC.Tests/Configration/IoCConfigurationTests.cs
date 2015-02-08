using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Planru.Crosscutting.IoC.Unity;
using Planru.Crosscutting.IoC.Tests.Assets;

namespace Planru.Crosscutting.IoC.Tests.Configration
{
    [TestFixture]
    public class IoCConfigurationTests
    {
        private IContainer _container;

        [SetUp]
        public void Init()
        {
            _container = new UnityContainer();
        }

        [Test]
        public void TestLoadConfig_ShouldLoadConfigCorrectly()
        {
            var service = _container.Resolve<IService>();
            Assert.IsNotNull(service, "Resolved object should be not null");
            Assert.IsInstanceOf(typeof(IService), service, "Resolved object should be an instance of IService");
        }
    }
}
