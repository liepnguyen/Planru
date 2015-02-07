using AutoMapper;
using System;
using System.Collections.Generic;

namespace Planru.Crosscutting.Adapter.Automapper
{
    /// <summary>
    /// Automapper type adapter implementation
    /// </summary>
    public class AutomapperTypeAdapter
        : ITypeAdapter
    {
        #region ITypeAdapter Members

        public TTarget Adapt<TSource, TTarget>(TSource source)
            //where TSource : class
            //where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) //where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }

        public object Adapt(object source, Type sourceType, Type targetType)
        {
            return Mapper.Map(source, sourceType, targetType);
        }

        public IMappingExpression<TSource, TTarget> CreateMap<TSource, TTarget>()
        {
            Mapper.CreateMap<TSource, TTarget>();
            return new AutomapperMappingExpression<TSource, TTarget>();
        }

        #endregion
    }
}
