using Planru.Modules.Directory.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.WebAPI.Models
{
    /// <summary>
    /// Represent for a user model
    /// </summary>
    public class User : MUser
    {

        public Guid Id { get; set; }

        public string UserPrincipalName { get; set; }

        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
