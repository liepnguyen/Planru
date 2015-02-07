using Planru.Core.Domain;
using Planru.Crosscutting.Adapter;
using Planru.Plugins.Directory.Domain.Entities;
using Planru.Plugins.Directory.Domain.Repositories;
using Planru.Plugins.Directory.Domain.Services;
using Planru.Plugins.Directory.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Services.Impl
{
    public class UserService : Service<User, Guid>, IUserService
    {
        public UserService(ITypeAdapter typeAdapter, IUserRepository repository)
            : base(typeAdapter, repository)
        { 

        }
    }
}
