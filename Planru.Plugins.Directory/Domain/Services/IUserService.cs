using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Core.Domain;

namespace Planru.Modules.Directory.Domain.Services
{
    public interface IUserService : IService<User, Guid>
    {

    }
}
