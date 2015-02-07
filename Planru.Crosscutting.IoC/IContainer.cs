using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.IoC
{
    public enum LifeTimeOptions
    {
        TransientLifeTimeOption,
        ContainerControlledLifeTimeOption
    }

    public interface IContainer : IDisposable
    {
        void Register<TSource, TTarget>() where TTarget : TSource;

        void Register<TSource, TTarget>(LifeTimeOptions lifeTimeOption) where TTarget : TSource;

        void Register(Type sourceType, Type targetType);

        void Register(Type sourceType, Type targetType, LifeTimeOptions lifeTimeOption);

        void RegisterInstance<T>(object instant);

        T Resolve<T>();

        object Resolve(Type T);

        IEnumerable<object> ResolveAll(Type T);
    }
}
