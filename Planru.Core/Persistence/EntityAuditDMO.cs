using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence
{
    public abstract class EntityAuditDMO<TID> : EntityDMO<TID>
    {
        public DateTime? WhenCreated { get; set; }
        public DateTime? WhenChanged { get; set; }
    }
}
