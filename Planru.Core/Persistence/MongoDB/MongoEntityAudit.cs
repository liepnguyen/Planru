using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MongoEntityAudit<TID> : EntityAudit<TID>
    {
        /// <inheritdoc />
        public override TID Id { get; set; }

        /// <inheritdoc />
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public override DateTime? WhenCreated { get; set; }

        /// <inheritdoc />
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public override DateTime? WhenChanged { get; set; }
    }
}
