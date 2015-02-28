﻿using Planru.Core.Domain;
using Planru.Crosscutting.Adapter;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Domain.Repositories;
using Planru.Modules.Directory.Domain.Services;
using Planru.Modules.Directory.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Services.Impl
{
    public class GroupService : Service<Group, Guid>, IGroupService
    {
        public GroupService(ITypeAdapter typeAdapter, IGroupRepository repository) 
            : base(typeAdapter, repository)
        { 

        }
    }
}