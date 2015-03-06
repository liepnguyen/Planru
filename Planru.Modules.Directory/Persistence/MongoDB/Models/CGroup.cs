using Planru.Core.Domain;
using Planru.Core.Persistence;
using Planru.Core.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Persistence.MongoDB.Models
{
    /// <summary>
    /// Represent for a group
    /// </summary>
    [Collection("group")]
    public class CGroup : EntityAudit<Guid>
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

        /// <inheritdoc />
        public override DateTime? WhenCreated { get; set; }

        /// <inheritdoc />
        public override DateTime? WhenChanged { get; set; }
    }
}
