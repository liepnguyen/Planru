using MongoDB.Driver;
using Planru.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence.MongoDB
{
    public abstract class Repository<TEntity, TID> : IRepository<TEntity, TID>
        where TEntity : IEntity<TID>
    {
        public Repository(MongoDatabase database)
        { 

        }

        public void Add(TEntity item)
        {
            throw new NotImplementedException();
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
