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
        private Expression<Func<TSource, object>> _sourceMember;

        public void MapFrom(Expression<Func<TSource, object>> sourceMember)
        {
            _sourceMember = sourceMember;
        }

        public Expression<Func<TSource, object>> SourceMember { get { return _sourceMember; } }

        public void Ignore()
        {
            throw new NotImplementedException();
        }
    }
}
