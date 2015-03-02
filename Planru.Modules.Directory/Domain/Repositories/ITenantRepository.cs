using Planru.Core.Persistence;
using Planru.Modules.Directory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Domain.Repositories
{
    /// <summary>
    /// Provide a repository for tenant entity
    /// </summary>
    public interface ITenantRepository : IRepository<Tenant, Guid>
    {

    }
}
