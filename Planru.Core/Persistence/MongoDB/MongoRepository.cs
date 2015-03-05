using MongoDB.Driver;
using Planru.Core.Configuration.Annotations;
using Planru.Core.Domain;
using Planru.Crosscutting.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence.MongoDB
{
    public abstract class MongoRepository<TEntity, TID> : IRepository<TEntity, TID>
        where TEntity : Entity<TID>
    {
        private readonly string _connectionString;
        private readonly string _databaseName;

        private readonly MongoServer _server;
        private readonly MongoClient _client;
        private readonly MongoDatabase _db;

        public MongoRepository(string connectionString, string databaseName)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;

            _client = new MongoClient(connectionString);
            _server = _client.GetServer();
            _db = _server.GetDatabase(databaseName);
        }

        protected virtual string GetCollectionName()
        {
            var collectionName = ((CollectionAttribute)typeof(TEntity).GetCustomAttributes(true)
                    .FirstOrDefault(attr => attr.GetType() == typeof(CollectionAttribute))).Name;

            return collectionName;
        }

        public void Add(TEntity item)
        {
            
        }

        public void Add(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Remove(TID id)
        {
            throw new NotImplementedException();
        }

        public void Remove(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public void Remove(IEnumerable<TID> ids)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void Modify(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Modify(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TID id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Exists(TID id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> AllMatching(Domain.Specification.ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }

        public Crosscutting.Data.PageResult<TEntity> GetPaged<KProperty>(int pageNumber, int pageSize, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
