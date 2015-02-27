using Planru.Core.Domain;
using Planru.Core.Persistence;
using Planru.Core.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Persistence.MongoDB.Models
{
    [Collection("group")]
    public class GroupDMO : EntityAuditDMO<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
