using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence
{
    /// <summary>
    /// Represent an entity audit
    /// </summary>
    /// <typeparam name="TID">The type of identifer</typeparam>
    public abstract class EntityAudit<TID> : Entity<TID>
    {
        /// <summary>
        /// Gets or sets the created datetime
        /// </summary>
        public virtual DateTime? WhenCreated { get; set; }

        /// <summary>
        /// Gets or sets the updated datetime
        /// </summary>
        public virtual DateTime? WhenChanged { get; set; }

        /// <summary>
        /// Gets or sets the identifer of who created this entity
        /// </summary>
        public virtual TID WhoCreated { get; set; }

        /// <summary>
        /// Gets or sets the identifer fo who changed this entity
        /// </summary>
        public virtual TID WhoChanged { get; set; }
    }
}
