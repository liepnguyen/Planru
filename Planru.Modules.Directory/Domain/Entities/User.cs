using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Core.Domain;
using Planru.Core.Persistence.MongoDB;
using MongoDB.Bson;

namespace Planru.Modules.Directory.Domain.Entities
{
    public class User : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
    }
}
