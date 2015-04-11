using Planru.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Domain.Entities
{
    /// <summary>
    /// Represent for a group entity
    /// </summary>
    public class Group : Entity<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
