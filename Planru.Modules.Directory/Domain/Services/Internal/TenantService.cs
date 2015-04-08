using Planru.Core.Domain;
using Planru.Modules.Directory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Modules.Directory.Persistence.MongoDB.Repositories;

namespace Planru.Modules.Directory.Domain.Services.Internal
{
    public class TenantService : ITenantService
    {
        public TenantService(TenantRepository repository)
        { 

        }
    }
}
