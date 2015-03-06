using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Application.Models
{
    /// <summary>
    /// Represent a user model contract
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets and sets the indentifer
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets and sets the user principal name
        /// </summary>
        string UserPrincipalName { get; set; }

        /// <summary>
        /// Gets and sets the display name
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// Gets and sets the first name
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets and sets the last name
        /// </summary>
        string LastName { get; set; }
    }
}
