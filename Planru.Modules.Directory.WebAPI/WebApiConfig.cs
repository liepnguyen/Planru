using Planru.Core.Module.WebAPI;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.IoC;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Persistence.MongoDB;
using Planru.Modules.Directory.Persistence;
using Planru.Modules.Directory.Services;
using Planru.Modules.Directory.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Modules.Directory.Domain.Repositories;
using Planru.Modules.Directory.Domain.Services;
using Planru.Modules.Directory.Services.Internal;
using Planru.Modules.Directory.Persistence.MongoDB.Models;
using Planru.Modules.Directory.Application.DTOs;
using Planru.Modules.Directory.Application.Services;
using Planru.Modules.Directory.Application.Impl;
using Planru.Modules.Directory.Application.Models;

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
        }

        public void CreateMappings(ITypeAdapter typeAdapter)
        {
            // domain <-> persistence
            typeAdapter.CreateMap<TUser, User>();
            typeAdapter.CreateMap<User, TUser>();

            // domain <-> application
            typeAdapter.CreateMap<User, UserDTO>();
            typeAdapter.CreateMap<UserDTO, User>();
        }
    }
}
