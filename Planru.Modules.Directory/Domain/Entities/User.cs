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
    /// <summary>
    /// Represent for a user entity
    /// </summary>
    public class User : Entity<Guid>
    {
        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the display name
        /// </summary>
        public string DisplayName { get; set; }
    }
}
