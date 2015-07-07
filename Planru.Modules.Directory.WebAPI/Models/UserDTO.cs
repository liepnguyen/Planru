using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.WebAPI.Models
{
    /// <summary>
    /// Represent a user model
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Gets and sets the indentifer
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets and sets the user principal name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets and sets the display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets and sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets and sets the last name
        /// </summary>
        public string LastName { get; set; }
    }
}
