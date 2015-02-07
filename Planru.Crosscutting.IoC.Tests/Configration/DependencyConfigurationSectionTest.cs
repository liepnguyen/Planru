using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Planru.Crosscutting.IoC.Configuration.Elements;
using System.Configuration;
using Planru.Crosscutting.IoC.Configuration;
using System.Reflection;
using Planru.Crosscutting.IoC.Unity;
using Planru.Plugins.Directory.Domain.Repositories;
using Planru.Crosscutting.IoC.Tests.Assets;

namespace Planru.Crosscutting.IoC.Tests.Configration
{
    [TestFixture]
    public class DependencyConfigurationSectionTest
    {
        private IContainer _container;

        [SetUp]
        public void Init()
        {
            _container = new UnityContainer();
        }

        [Test]
        public void TestConfigurationSection_ShouldReturnConfigCorrectly()
        {
            DependencyConfigurationSection dependencyConfigurationSection =
                ConfigurationManager.GetSection("dependencyConfigSection") as DependencyConfigurationSection;

            foreach (DependencyElement dependencyElement in dependencyConfigurationSection.Dependencies)
            {
                var type = Type.GetType(dependencyElement.Type);
                var resolve = Type.GetType(dependencyElement.Resolve);

                _container.Register(type, resolve);
            }

            var service = _container.Resolve<IService>();
            Assert.IsNotNull(service, "Resolved object should be not null");
            Assert.IsInstanceOf(typeof(IService), service, "Resolved object should be an instance of IService");
        }
    }
}
