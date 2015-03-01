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
    public abstract class Service<TDomainEntity, TID> : IService<TDomainEntity, TID>
        where TDomainEntity : Entity<TID>
    {
        private bool _disposed = false;

        protected IRepository<TDomainEntity, TID> _repository;

        public Service(IRepository<TDomainEntity, TID> repository)
        {
            _repository = repository;
        }

        public TDomainEntity Get(TID id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<TDomainEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public PageResult<TDomainEntity> GetPaged<KProperty>(int pageNumber, int pageSize, Expression<Func<TDomainEntity, KProperty>> orderByExpression, bool ascending)
        {
            return _repository.GetPaged<KProperty>(pageNumber, pageSize, orderByExpression, ascending);
        }

        public void Add(TDomainEntity item)
        {
            _repository.Add(item);
        }

        public void Add(IEnumerable<TDomainEntity> items)
        {
            _repository.Add(items);
        }

        public void Remove(TDomainEntity item)
        {
            _repository.Remove(item);
        }

        public void Remove(IEnumerable<TDomainEntity> items)
        {
            _repository.Remove(items);
        }

        public void Remove(TID id)
        {
            _repository.Remove(id);
        }

        public void Remove(IEnumerable<TID> ids)
        {
            _repository.Remove(ids);
        }

        public void Modify(TDomainEntity item)
        {
            _repository.Modify(item);
        }

        public void Modify(IEnumerable<TDomainEntity> items)
        {
            _repository.Modify(items);
        }

        public Task<TDomainEntity> GetAsync(TID id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDomainEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<TDomainEntity>> GetPagedAsync<KProperty>(int pageNumber, int pageSize, Expression<Func<TDomainEntity, KProperty>> orderByExpression, bool ascending)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TDomainEntity item)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(IEnumerable<TDomainEntity> items)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TDomainEntity item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(IEnumerable<TDomainEntity> items)
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

        public Task ModifyAsync(TDomainEntity item)
        {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(IEnumerable<TDomainEntity> items)
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
