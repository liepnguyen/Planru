using Planru.Core.Domain;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Domain.Services.Impl
{
    public class RoleService : Service<Role, Guid>, IRoleService
    {
        public RoleService(IRoleRepository repository)
            : base(repository)
        { 
            
        }
    }
}
