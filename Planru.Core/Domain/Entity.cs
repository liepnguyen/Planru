using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Domain
{
    public abstract class Entity<TID>
    {
        public virtual TID Id { get; set; }
    }
}
