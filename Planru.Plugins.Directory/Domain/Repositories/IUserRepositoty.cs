using MongoDB.Bson;
using Planru.Core.Domain;
using Planru.Core.Persistence;
using Planru.Core.Persistence.MongoDB;
using Planru.Plugins.Directory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {

    }
}
