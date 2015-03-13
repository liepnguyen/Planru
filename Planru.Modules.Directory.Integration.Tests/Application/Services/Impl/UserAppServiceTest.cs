﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planru.Core.Persistence;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Application.Services;
using Planru.Modules.Directory.Persistence.MongoDB;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.Adapter.Automapper;
using Planru.Modules.Directory.Application.Models;
using Planru.Modules.Directory.Application.Services.Impl;
using Planru.Modules.Directory.Domain.Services.Impl;
using System.Collections.Generic;
using Planru.Modules.Directory.Domain.Repositories;
using System.Linq;
using Planru.Modules.Directory.Persistence.MongoDB.Models;

namespace Planru.Modules.Directory.Integration.Tests.Application.Services.Impl
{
    [TestClass]
    public class UserAppServiceTest
    {
        private IUserAppService _userAppService;
        private IUserRepository _userRepository;

        [TestInitialize]
        public void Initialize()
        {
            var connectionString = "mongodb://liepnguyen:abcd1234@ds055680.mongolab.com:55680/planru_system";
            var databaseName = "planru_system";
            _userRepository = new UserRepository(connectionString, databaseName);
            var userService = new UserService(_userRepository);
            
            TypeAdapterFactory.SetCurrent(new AutomapperTypeAdapterFactory());
            var adapter = TypeAdapterFactory.CreateAdapter();

            adapter.CreateMap<User, UserDTO>();
            adapter.CreateMap<UserDTO, User>();

            adapter.CreateMap<User, TUser>();
            adapter.CreateMap<TUser, User>();

            _userRepository.RemoveAll();
            _userAppService = new UserAppService(userService, _userRepository);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _userRepository.RemoveAll();
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void Test_GetUsers_Method_Should_Return_Correct_Value()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { Id = Guid.NewGuid(), FirstName = "A" },
                new User() { Id = Guid.NewGuid(), FirstName = "C" },
                new User() { Id = Guid.NewGuid(), FirstName = "B" }
            };
            _userRepository.Add(users);

            // Action
            var actualUsers = _userAppService.GetUsers<string>(1, 2, k => k.FirstName, true);

            // Assert
            Assert.IsNotNull(actualUsers);
            Assert.AreEqual(3, actualUsers.TotalItems);
            Assert.AreEqual(1, actualUsers.Items.Count());
            Assert.AreEqual("C", actualUsers.Items.First().FirstName);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void Test_CreateUser_Method_Should_Create_User_Correctly()
        { 

        }

        [TestMethod]
        [TestCategory("Integration")]
        public void Test_UpdateUser_Method_Should_Update_User_Correctly()
        { 
        
        }
    }
}
