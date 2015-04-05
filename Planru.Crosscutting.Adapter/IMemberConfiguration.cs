﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Planru.Crosscutting.Adapter
{
    public interface IMemberConfiguration<TSource>
    {
        Expression<Func<TSource, object>> SourceMember { get; }
        void MapFrom(Expression<Func<TSource, object>> sourceMember);
        void Ignore();
    }
}
