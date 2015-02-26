using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Plugins.Directory.Domain.Entities;
using Planru.Core.Domain;

namespace Planru.Plugins.Directory.Domain.Services
{
    public interface IUserService : IService<IUser, Guid>
    {

    }
}
