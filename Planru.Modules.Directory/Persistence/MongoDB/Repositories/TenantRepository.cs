using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Core.Persistence.MongoDB;
using Planru.Modules.Directory.Persistence.MongoDB.Models;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Domain.Repositories;
using MongoDB.Driver;

namespace Planru.Modules.Directory.Persistence.MongoDB.Repositories
{
    public class TenantRepository : Repository<CTenant, Tenant, Guid>, ITenantRepository
    {
        public TenantRepository(MongoDatabase database)
            : base(database)
        { 
            
        }
    }
}
