using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;

namespace Planru.Crosscutting.Adapter.Automapper
{
    public class AutomapperMemberConfiguration<TSource> : IMemberConfiguration<TSource>
    {
        public Expression<Func<TSource, object>> SourceMember { get; private set; }

        public void MapFrom(Expression<Func<TSource, object>> sourceMember)
        {
            this.SourceMember = sourceMember;
        }

        public void Ignore()
        {
            this.SourceMember = null;
        }
    }
}
