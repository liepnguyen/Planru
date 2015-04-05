using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Planru.Crosscutting.Adapter
{
    public interface IMemberConfiguration<TSource, TTarget>
    {
        /// <summary>
        /// Specify the source member to map from
        /// </summary>
        /// <param name="sourceMember"></param>
        void MapFrom(Expression<Func<TSource, object>> sourceMember);

        /// <summary>
        /// Ignore this member for configuration validation and skip during mapping
        /// </summary>
        void Ignore();
    }
}
