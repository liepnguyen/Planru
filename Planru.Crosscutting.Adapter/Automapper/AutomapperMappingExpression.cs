using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Crosscutting.Adapter.Automapper
{
    public class AutomapperMappingExpression<TSource, TTarget> : IMappingExpression<TSource, TTarget>
    {
        public IMappingExpression<TSource, TTarget> ForMember(Expression<Func<TTarget, object>> destinationMember, 
            Action<IMemberConfiguration<TSource, TTarget>> memberOptions)
        {
            memberOptions(new AutomapperMemberConfiguration<TSource, TTarget>(destinationMember));
            return new AutomapperMappingExpression<TSource, TTarget>();
        }
    }
}
