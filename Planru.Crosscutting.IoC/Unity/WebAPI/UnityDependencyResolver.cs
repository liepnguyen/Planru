using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Planru.Crosscutting.IoC.Unity.WebAPI
{
    public class UnityDependencyResolver : IDependencyResolver, IDependencyScope
    {
        private bool _disposed = false;

        private IContainer _container;
        public UnityDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // 
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);     
        }
    }
}
