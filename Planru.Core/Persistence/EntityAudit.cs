using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence
{
    public abstract class EntityAudit<TID> : Entity<TID>
    {
        public abstract DateTime? WhenCreated { get; set; }
        public abstract DateTime? WhenChanged { get; set; }
    }
}
