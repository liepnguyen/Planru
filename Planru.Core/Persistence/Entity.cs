using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence
{
    /// <summary>
    /// Represent for an entity
    /// </summary>
    /// <typeparam name="TID">The type of identifer</typeparam>
    public abstract class Entity<TID>
    {
        /// <summary>
        /// Gets or sets the indentifer
        /// </summary>
        public virtual TID Id { get; set; }
    }
}
