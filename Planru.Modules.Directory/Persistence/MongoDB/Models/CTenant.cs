﻿using Planru.Core.Configuration.Annotations;
using Planru.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Persistence.MongoDB.Models
{
    /// <summary>
    /// Represent for a tenant (organization)
    /// </summary>
    [Collection("tenant")]
    public class CTenant : EntityAudit<Guid>
    {
        /// <inheritdoc />
        public override Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        public string State { get; set; }

        /// <inheritdoc />
        public override DateTime? WhenCreated { get; set; }

        /// <inheritdoc />
        public override DateTime? WhenChanged { get; set; }
    }
}
