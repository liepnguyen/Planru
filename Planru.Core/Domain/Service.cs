using Planru.Core.Domain;
using Planru.Core.Persistence;
using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Domain
{
    public abstract class Service<TEntity, TID> : IService<TEntity, TID>
        where TEntity : IEntity<TID>
    {
        private bool _disposed = false;

        protected IRepository<TEntity, TID> _repository;
        protected ITypeAdapter _typeAdapter;

        public Service(ITypeAdapter typeAdapter, IRepository<TEntity, TID> repository)
        {
            _typeAdapter = typeAdapter;
            _repository = repository;
        }

        public TEntity Get(TID id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public PageResult<TEntity> GetPaged<KProperty>(int pageNumber, int pageSize, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            throw new NotImplementedException();
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

        public void Remove(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public void Remove(TID id)
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

        public Task<TEntity> GetAsync(TID id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<TEntity>> GetPagedAsync<KProperty>(int pageNumber, int pageSize, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TID id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(IEnumerable<TID> ids)
        {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
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
