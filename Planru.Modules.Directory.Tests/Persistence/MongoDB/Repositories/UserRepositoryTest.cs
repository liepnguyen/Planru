using MongoDB.Driver;
using NUnit.Framework;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.Adapter.Automapper;
using Planru.Crosscutting.IoC;
using Planru.Crosscutting.IoC.Unity;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Domain.Repositories;
using Planru.Modules.Directory.Persistence.MongoDB;
using Planru.Modules.Directory.Persistence.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Tests.Persistence.MongoDB.Repositories
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private IUserRepository _userRepository;

        [SetUp]
        public void SetUp()
        {
            this.Initialize();
            _userRepository.RemoveAll();
        }

        [TearDown]
        public void TearDown()
        {
            _userRepository.RemoveAll();
        }

        [TestCase]
        public void Add_AddNewUser_NewUserIsCreated()
        {
            var expected = new User()
            {
                Id = Guid.NewGuid(),
                UserName = "liepnguyen",
                FirstName = "Liep",
                LastName ="Nguyen",
                DisplayName = "Liep Nguyen"
            };

            _userRepository.Add(expected);

            var users = _userRepository.GetAll();
            var actual = users.FirstOrDefault();
            Assert.AreEqual(1, users.Count());
            AssertTwoUsersAreEqual(expected, actual);
        }

        #region Private methods
        private void Initialize()
        {
            var credential = MongoCredential.CreateMongoCRCredential("planru_system", "liepnguyen", "@dmin348");

            var settings = new MongoClientSettings
            {
                Credentials = new[] { credential },
                Server = new MongoServerAddress("ds055680.mongolab.com", 55680)
            };

            var client = new MongoClient(settings);
            var server = client.GetServer();
            var database = server.GetDatabase("planru_system");

            TypeAdapterFactory.SetCurrent(new AutomapperTypeAdapterFactory());
            _userRepository = new UserRepository(database);

            var adapter = TypeAdapterFactory.CreateAdapter();

            adapter.CreateMap<CUser, User>();
            adapter.CreateMap<User, CUser>();
        }

        private void AssertTwoUsersAreEqual(User expected, User actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.UserName, actual.UserName);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }
        #endregion
    }
}
