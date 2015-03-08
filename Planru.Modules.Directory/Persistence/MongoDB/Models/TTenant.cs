﻿using MongoDB.Bson.Serialization.Attributes;
using Planru.Core.Configuration.Annotations;
using Planru.Core.Persistence;
using Planru.Core.Persistence.MongoDB;
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
    [Collection("user")]
    public class TTenant : EntityAudit<Guid>
    {
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
    }
}
