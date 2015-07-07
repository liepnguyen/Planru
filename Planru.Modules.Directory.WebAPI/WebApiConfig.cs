using Planru.Core.Module.WebAPI;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.IoC;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Persistence.MongoDB;
using Planru.Modules.Directory.Persistence;
using Planru.Modules.Directory.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Modules.Directory.Domain.Repositories;
using Planru.Modules.Directory.Domain.Services;
using Planru.Modules.Directory.Persistence.MongoDB.Models;
using Planru.Modules.Directory.Domain.Services.Internal;
using MongoDB.Bson.Serialization.Conventions;
using Planru.Core.Persistence.MongoDB;
using Planru.Modules.Directory.WebAPI.Models;
using Planru.Modules.Directory.WebAPI.Services;
using Planru.Modules.Directory.WebAPI.Services.Internal;

namespace Planru.Modules.Directory.WebAPI
{
    public class WebApiConfig : IWebApiConfig
    {
        public void RegisterTypes(IContainer container)
        {
            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserService, UserService>();
            container.Register<IUserAppService, UserAppService>();
            container.Register<UserController, UserController>();

            container.Register<IGroupRepository, GroupRepository>();
            container.Register<IGroupService, GroupService>();
            container.Register<IGroupAppService, GroupAppService>();
            container.Register<GroupController, GroupController>();
        }

        public void CreateMappings(ITypeAdapter typeAdapter)
        {
            // domain <-> persistence
            typeAdapter.CreateMap<TUser, User>();
            typeAdapter.CreateMap<User, TUser>();
            typeAdapter.CreateMap<TGroup, Group>();
            typeAdapter.CreateMap<Group, TGroup>();

            // domain <-> application
            typeAdapter.CreateMap<User, UserDTO>();
            typeAdapter.CreateMap<UserDTO, User>();
            typeAdapter.CreateMap<Group, GroupDTO>();
            typeAdapter.CreateMap<GroupDTO, Group>();
        }
    }
}
