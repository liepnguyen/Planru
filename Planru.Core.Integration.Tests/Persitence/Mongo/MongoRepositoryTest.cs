using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planru.Core.Domain;
using Planru.Core.Persistence;
using Planru.Core.Persistence.MongoDB;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.Adapter.Automapper;
using Planru.Core.Configuration.Annotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Planru.Core.Integration.Tests.Persitence.Mongo
{
    

    [TestClass]
    public class MongoRepositoryTest
    {
        #region Inner classes

        public class TestDomainEntity : Planru.Core.Domain.Entity<Guid>
        {
            public string StringValue { get; set; }
            public int IntegerValue { get; set; }
            public DateTime DateTimeValue { get; set; }
        }

        [Collection("test_repository")]
        public class TestPersistenceEntity : Planru.Core.Persistence.Entity<Guid>
        {
            public string StringValue { get; set; }
            public int IntegerValue { get; set; }
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime DateTimeValue { get; set; }
        }

        public class MongoTestRepository : MongoRepository<TestPersistenceEntity, TestDomainEntity, Guid>
        {
            public MongoTestRepository(string connectionString, string databaseName)
                : base(connectionString, databaseName)
            {

            }
        }

        #endregion

        private IRepository<TestDomainEntity, Guid> _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new MongoTestRepository(
                "mongodb://liepnguyen:abcd1234@ds055680.mongolab.com:55680/planru_system", 
                "planru_system");

            _repository.RemoveAll();

            TypeAdapterFactory.SetCurrent(new AutomapperTypeAdapterFactory());
            var adapter = TypeAdapterFactory.CreateAdapter();

            adapter.CreateMap<TestDomainEntity, TestPersistenceEntity>();
            adapter.CreateMap<TestPersistenceEntity, TestDomainEntity>();
        }

        [TestMethod]
        public void Add_MethodIsCalled_AnEntityIsAdded()
        {
            // Arrange
            var expected = new TestDomainEntity() 
            { 
                Id = Guid.NewGuid(),
                StringValue = "test value",
                IntegerValue = 1212,
                DateTimeValue = DateTime.Now
            };
            _repository.Add(expected);

            // Action
            var allEntities = _repository.GetAll();
            var actual = allEntities.FirstOrDefault();

            // Assert
            Assert.AreEqual(1, allEntities.Count());
            Assert.IsNotNull(actual);
            AssertAreEqual(expected, actual);
        }

        [TestMethod]
        public void Get_MethodIsCalledWithId_AnEntityIsReturned()
        {
            // Arrange
            var expected = new TestDomainEntity()
            {
                Id = Guid.NewGuid(),
                StringValue = "test value",
                IntegerValue = 1212,
                DateTimeValue = DateTime.Now
            };
            _repository.Add(expected);

            // Action
            var actual = _repository.Get(expected.Id);

            // Assert
            Assert.IsNotNull(actual);
            AssertAreEqual(expected, actual);
        }

        [TestMethod]
        public void Modify_MethodIsCalled_AnEntityIsModified()
        {
            // Arrange
            var expected = new TestDomainEntity()
            {
                Id = Guid.NewGuid(),
                StringValue = "test value",
                IntegerValue = 1212,
                DateTimeValue = DateTime.Now
            };
            _repository.Add(expected);

            // Action
            expected.IntegerValue = 12;
            expected.StringValue = "another test value";
            expected.DateTimeValue = DateTime.Now.AddDays(2);
            _repository.Modify(expected);
            var actual = _repository.Get(expected.Id);

            // Assert
            Assert.IsNotNull(actual);
            AssertAreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_MethodIsCalled_AnEntityIsRemoved()
        {
            // Arrange
            var entity = new TestDomainEntity() { Id = Guid.NewGuid() };
            
            // Action
            _repository.Add(entity);
            _repository.Remove(entity.Id);

            // Assert
            var actual = _repository.Get(entity.Id);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Exists_MethodIsCalled_CorrectValueIsReturned()
        {
            // Arrange
            var entity = new TestDomainEntity() { Id = Guid.NewGuid() };

            // Action
            _repository.Add(entity);

            // Assert
            Assert.AreEqual(false, _repository.Exists(Guid.NewGuid()));
            Assert.AreEqual(true, _repository.Exists(entity.Id));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _repository.RemoveAll();
        }

        #region Private methods
        public void AssertAreEqual(TestDomainEntity expected, TestDomainEntity actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.StringValue, actual.StringValue);
            Assert.AreEqual(expected.IntegerValue, actual.IntegerValue);
            Assert.AreEqual(expected.DateTimeValue.ToLongTimeString(), actual.DateTimeValue.ToLongTimeString());
        }
        #endregion
    }
}
