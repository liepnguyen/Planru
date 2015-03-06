using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence
{
    public abstract class Entity<TID>
    {
        public abstract TID Id { get; set; }
    }
}
