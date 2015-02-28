﻿using MongoDB.Driver;
using Planru.Core.Persistence.MongoDB;
using Planru.Crosscutting.Adapter;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Domain.Repositories;
using Planru.Modules.Directory.Persistence;
using Planru.Modules.Directory.Persistence.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Persistence.MongoDB
{
    public class UserRepository : Repository<UserDMO, User, Guid>, IUserRepository
    {
        public UserRepository(MongoDatabase database, ITypeAdapter typeAdapter)
            : base(database, typeAdapter)
        {

        }
    }
}