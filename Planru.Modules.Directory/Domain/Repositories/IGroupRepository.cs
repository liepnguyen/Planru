using MongoDB.Bson;
using Planru.Core.Domain;
using Planru.Core.Persistence;
using Planru.Core.Persistence.MongoDB;
using Planru.Modules.Directory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Domain.Repositories
{
    public interface IGroupRepository : IRepository<Group, Guid>
    {

    }
}
