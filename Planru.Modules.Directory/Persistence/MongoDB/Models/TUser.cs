using Planru.Core.Domain;
using Planru.Core.Persistence;
using Planru.Core.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using Planru.Core.Persistence.MongoDB;

namespace Planru.Modules.Directory.Persistence.MongoDB.Models
{
    /// <summary>
    /// Represent for a user
    /// </summary>
    [Collection("user")]
    public class TUser : EntityAudit<Guid>
    {
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        [BsonElement("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the display name
        /// </summary>
        [BsonElement("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        [BsonElement("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        [BsonElement("last_name")]
        public string LastName { get; set; }
    }
}
