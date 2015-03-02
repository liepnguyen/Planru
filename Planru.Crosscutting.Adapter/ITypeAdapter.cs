using System;
using System.Linq.Expressions;
namespace Planru.Crosscutting.Adapter
{
    /// <summary>
    /// Base contract for map dto to aggregate or aggregate to dto.
    /// <remarks>
    /// This is a contract for work with "auto" mappers (automapper, emitmapper, valueinjecter...)
    /// or adhoc mappers
    /// </remarks>
    /// </summary>
    public interface ITypeAdapter
    {
        /// <summary>
        /// Adapt a source object to an instance of type <paramref name="TTarget"/>
        /// </summary>
        /// <typeparam name="TSource">Type of source item</typeparam>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns><paramref name="source"/> mapped to <typeparamref name="TTarget"/></returns>
        TTarget Adapt<TSource, TTarget>(TSource source);

        /// <summary>
        /// Adapt a source object to an instnace of type <paramref name="TTarget"/>
        /// </summary>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns><paramref name="source"/> mapped to <typeparamref name="TTarget"/></returns>
        TTarget Adapt<TTarget>(object source);

        object Adapt(object source, Type TSource, Type TTarget);

        IMappingExpression<TSource, TTarget> CreateMap<TSource, TTarget>();
    }
}
