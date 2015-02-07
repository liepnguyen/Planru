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
        private Lazy<IMemberConfiguration<TSource>> _memberConfiguration = 
            new Lazy<IMemberConfiguration<TSource>>(() =>
        {
            var memberConfiguration = new AutomapperMemberConfiguration<TSource>();
            return memberConfiguration;
        });

        public IMemberConfiguration<TSource> MemberConfiguration
        { 
            get { return _memberConfiguration.Value; } 
        }

        public IMappingExpression<TSource, TTarget> ForMember(Expression<Func<TTarget, object>> destinationMember, 
            Action<IMemberConfiguration<TSource>> memberOptions)
        {
            memberOptions(_memberConfiguration.Value);

            Mapper.CreateMap<TSource, TTarget>()
                .ForMember(destinationMember, m => m.MapFrom(MemberConfiguration.SourceMember));

            return this;
        }
    }
}
