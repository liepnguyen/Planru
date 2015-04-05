using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;

namespace Planru.Crosscutting.Adapter.Automapper
{
    public class AutomapperMemberConfiguration<TSource, TTarget> : IMemberConfiguration<TSource, TTarget>
    {
        public Expression<Func<TTarget, object>> DestinationMember { get; private set; }

        public AutomapperMemberConfiguration(Expression<Func<TTarget, object>> destinationMember)
        {
            if (destinationMember == null)
                throw new ArgumentNullException("destinationMember");

            this.DestinationMember = destinationMember;
        }

        public void MapFrom(Expression<Func<TSource, object>> sourceMember)
        {
            Mapper.CreateMap<TSource, TTarget>().ForMember(this.DestinationMember, opt => opt.MapFrom(sourceMember));
        }

        public void Ignore()
        {
            Mapper.CreateMap<TSource, TTarget>().ForMember(this.DestinationMember, opt => opt.Ignore());
        }
    }
}
