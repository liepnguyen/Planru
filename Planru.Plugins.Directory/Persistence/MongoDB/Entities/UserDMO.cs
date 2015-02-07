using Planru.Core.Domain;
using Planru.Core.Persistence;
using Planru.Core.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Persistence.MongoDB.Entities
{
    [Collection("user")]
    public class UserDMO : EntityAuditDMO<Guid>
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
