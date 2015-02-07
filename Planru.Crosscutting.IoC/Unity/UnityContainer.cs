using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.IoC.Unity
{
    public class UnityContainer : IContainer
    {
        private bool _disposed = false;

        private IUnityContainer _unityContainer;

        public UnityContainer() 
        {
            _unityContainer = new Microsoft.Practices.Unity.UnityContainer();
        }

        public void Register<TSource, TTarget>() where TTarget : TSource
        {
            _unityContainer.RegisterType<TSource, TTarget>();
        }

        public void Register<TSource, TTarget>(LifeTimeOptions lifeTimeOption) where TTarget : TSource
        {
            this.Register(typeof(TSource), typeof(TTarget), lifeTimeOption);
        }

        public void Register(Type sourceType, Type targetType)
        {
            _unityContainer.RegisterType(sourceType, targetType);
        }

        public void Register(Type sourceType, Type targetType, LifeTimeOptions lifeTimeOption)
        {
            LifetimeManager lifetimeManager = null;
            if (lifeTimeOption == LifeTimeOptions.TransientLifeTimeOption)
                lifetimeManager = new TransientLifetimeManager();
            else if (lifeTimeOption == LifeTimeOptions.ContainerControlledLifeTimeOption)
                lifetimeManager = new ContainerControlledLifetimeManager();

            _unityContainer.RegisterType(sourceType, targetType, lifetimeManager);
        }

        public void RegisterInstance<T>(object instance)
        {
            _unityContainer.RegisterInstance(typeof(T), instance);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type T)
        {
            return _unityContainer.Resolve(T);
        }

        public IEnumerable<object> ResolveAll(Type T)
        {
            return _unityContainer.ResolveAll(T);
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
