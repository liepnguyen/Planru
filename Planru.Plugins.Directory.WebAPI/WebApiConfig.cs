using Planru.Core.Plugin.WebAPI;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.IoC;
using Planru.Plugins.Directory.Domain.Entities;
using Planru.Plugins.Directory.Persistence.MongoDB;
using Planru.Plugins.Directory.Persistence;
using Planru.Plugins.Directory.Services;
using Planru.Plugins.Directory.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Plugins.Directory.Domain.Repositories;
using Planru.Plugins.Directory.Domain.Services;
using Planru.Plugins.Directory.Services.Impl;
using Planru.Plugins.Directory.Persistence.MongoDB.Entities;
using Planru.Plugins.Directory.Application.DTOs;
using Planru.Plugins.Directory.Application.Services;
using Planru.Plugins.Directory.Application.Impl;

namespace Planru.Plugins.Directory.WebAPI
{
    public class WebApiConfig : IWebApiConfig
    {
        public void RegisterTypes(IContainer container)
        {
            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserService, UserService>();
            container.Register<IUserAppService, UserAppService>();
            container.Register<UserController, UserController>();
        }

        public void CreateMappings(ITypeAdapter typeAdapter)
        {
            // domain <-> persistence
            typeAdapter.CreateMap<UserDMO, User>();
            typeAdapter.CreateMap<User, UserDMO>();

            // domain <-> application
            typeAdapter.CreateMap<User, UserDTO>();
            typeAdapter.CreateMap<UserDTO, User>();
        }
    }
}
