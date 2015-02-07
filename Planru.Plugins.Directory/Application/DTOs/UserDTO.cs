using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Application.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
