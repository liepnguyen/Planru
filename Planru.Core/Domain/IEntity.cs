using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Domain
{
    public interface IEntity<TID>
    {
        TID Id { get; }
    }
}
