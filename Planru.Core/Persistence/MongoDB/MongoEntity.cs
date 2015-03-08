using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence.MongoDB
{
    /// <summary>
    /// Represent for a Mongo Entity
    /// </summary>
    /// <typeparam name="TID">The type of indentifer</typeparam>
    public abstract class MongoEntity<TID> : Entity<TID> 
    {
        /// <inheritdoc />
        public override TID Id { get; set; }
    }
}
