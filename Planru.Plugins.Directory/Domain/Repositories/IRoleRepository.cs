using Planru.Core.Persistence;
using Planru.Plugins.Directory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Domain.Repositories
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {

    }
}
