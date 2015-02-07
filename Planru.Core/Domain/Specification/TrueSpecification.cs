using System;
using System.Linq.Expressions;

namespace Planru.Core.Domain.Specification
{
    /// <summary>
    /// True specification
    /// </summary>
    /// <typeparam name="TEntity">Type of entity in this specification</typeparam>
    public sealed class TrueSpecification<TEntity>
        :Specification<TEntity>
        where TEntity:class
    {
        #region Specification overrides

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            //Create "result variable" transform adhoc execution plan in prepared plan
            bool result = true;

            Expression<Func<TEntity, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }
}
