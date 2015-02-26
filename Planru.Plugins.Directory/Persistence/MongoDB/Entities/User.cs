using Planru.Core.Configuration.Annotations;
using Planru.Plugins.Directory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Persistence.MongoDB.Entities
{
    [Collection("user")]
    public class User : IUser
    {
        public Guid Id { get; set; }

        public string UserPrincipalName { get; set; }

        public string FirstName { get; set; }

        public string LastNam { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }
    }
}
