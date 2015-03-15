using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Core.Domain.Specification;
using Planru.Core.Domain;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Data.Entity.Design.PluralizationServices;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using Planru.Crosscutting.Data;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.Common;
using Planru.Core.Configuration.Annotations;

namespace Planru.Core.Persistence.MongoDB
{
    /// <summary>
    /// Represent for a Mongo repository
    /// </summary>
    /// <typeparam name="TPersistenceEntity">The type of persistence entity</typeparam>
    /// <typeparam name="TDomainEntity">The type of domain entity</typeparam>
    /// <typeparam name="TID">The type of indentifer</typeparam>
    public abstract class MongoRepository<TPersistenceEntity, TDomainEntity, TID> : IRepository<TDomainEntity, TID>
        where TDomainEntity : Planru.Core.Domain.Entity<TID>
        where TPersistenceEntity : Planru.Core.Persistence.Entity<TID>
    {
        private bool _disposed = false;
        private MongoCollection<TPersistenceEntity> _collection;

        public MongoRepository(IMongoDbContext mongoDatabaseManager)
        {
            _collection = mongoDatabaseManager.GetCollection<TPersistenceEntity>();
        }

        public void Add(TDomainEntity item)
        {
            var entity = item.Adapt<TPersistenceEntity>();
            _collection.Insert(entity);
        }

        public void Add(IEnumerable<TDomainEntity> items)
        {
            var entities = items.AdaptMany<TPersistenceEntity>();
            _collection.InsertBatch(items);
        }

        public void Remove(TDomainEntity item)
        {
            this.Remove(item.Id);
        }

        public void Remove(TID id)
        {
            _collection.Remove(Query.EQ("_id", BsonValue.Create(id)));
        }

        public void Remove(IEnumerable<TDomainEntity> items)
        {
            IEnumerable<TID> ids = items.Select(e => e.Id);
            Remove(ids);
        }

        public void Remove(IEnumerable<TID> ids)
        {
            _collection.Remove(Query.In("_id", new BsonArray(ids)));
        }

        public void RemoveAll()
        {
            _collection.RemoveAll();
        }

        public void Modify(TDomainEntity item)
        {
            var entity = item.Adapt<TPersistenceEntity>();
            _collection.Save(item);
        }

        public void Modify(IEnumerable<TDomainEntity> items)
        {
            var entities = items.AdaptMany<TPersistenceEntity>();
            _collection.Save(items);
        }

        public bool Exists(TID id)
        {
            return _collection.AsQueryable<TPersistenceEntity>().Any(e => e.Id.Equals(id));
        }

        public TDomainEntity Get(TID id)
        {
            var result = _collection.FindOneById(BsonValue.Create(id));
            return result.Adapt<TDomainEntity>();
        }

        public IEnumerable<TDomainEntity> GetAll()
        {
            var result = _collection.FindAll().AsEnumerable();
            return result.AdaptMany<TDomainEntity>();
        }

        public IEnumerable<TDomainEntity> AllMatching(ISpecification<TDomainEntity> specification)
        {
            return this.GetFiltered(specification.SatisfiedBy());
        }

        public PageResult<TDomainEntity> GetPaged<KProperty>(int pageNumber, int pageSize, 
            Expression<Func<TDomainEntity, KProperty>> orderByExpression, bool ascending)
        {
            var newOrderByExpression = 
                ExpressionConverter<TPersistenceEntity>.Convert(orderByExpression);

            IEnumerable<TPersistenceEntity> persistenceEntities;
            if (ascending)
                persistenceEntities = _collection.AsQueryable()
                                                    .OrderBy(newOrderByExpression)
                                                    .Skip(pageNumber * pageSize)
                                                    .Take(pageSize);
            else
                persistenceEntities = _collection.AsQueryable()
                                                    .OrderByDescending(newOrderByExpression)
                                                    .Skip(pageNumber * pageSize)
                                                    .Take(pageSize);
            var domainEntities = persistenceEntities.AdaptMany<TDomainEntity>();

            return new PageResult<TDomainEntity>(domainEntities, pageNumber, pageSize, this.Count());
        }

        public IEnumerable<TDomainEntity> GetFiltered(Expression<Func<TDomainEntity, bool>> filter)
        {
            var filterExpression = ExpressionConverter<TPersistenceEntity>.Convert(filter);

            var result = _collection.Find(Query<TPersistenceEntity>
                                    .Where(filterExpression))
                                    .Select(e => e.Adapt<TDomainEntity>());
            return result;
        }

        public long Count()
        {
            return _collection.Count();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // 
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
