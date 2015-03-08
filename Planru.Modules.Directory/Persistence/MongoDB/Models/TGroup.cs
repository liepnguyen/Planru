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
    /// Represent for a group
    /// </summary>
    [BsonDiscriminator("group")]
    public class TGroup : MongoEntityAudit<Guid>
    {
        /// <inheritdoc />
        public override Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
    }
}
