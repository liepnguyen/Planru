using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Adapter
{
    public interface IMappingExpression<TSource, TTarget>
    {
        IMappingExpression<TSource, TTarget> ForMember(Expression<Func<TTarget, object>> destinationMember, Action<IMemberConfiguration<TSource, TTarget>> memberOptions);
    }
}
