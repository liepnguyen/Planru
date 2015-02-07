using Planru.Crosscutting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Domain
{
    public interface IService<TDomainEntity, TID> : IDisposable
    {
        TDomainEntity Get(TID id);
        IEnumerable<TDomainEntity> GetAll();
        PageResult<TDomainEntity> GetPaged<KProperty>(int pageNumber, int pageSize, Expression<Func<TDomainEntity, KProperty>> orderByExpression, bool ascending);
        void Add(TDomainEntity item);
        void Add(IEnumerable<TDomainEntity> items);
        void Remove(TDomainEntity item);
        void Remove(IEnumerable<TDomainEntity> items);
        void Remove(TID id);
        void Remove(IEnumerable<TID> ids);
        void Modify(TDomainEntity item);
        void Modify(IEnumerable<TDomainEntity> items);
        Task<TDomainEntity> GetAsync(TID id);
        Task<IEnumerable<TDomainEntity>> GetAllAsync();
        Task<PageResult<TDomainEntity>> GetPagedAsync<KProperty>(int pageNumber, int pageSize, Expression<Func<TDomainEntity, KProperty>> orderByExpression, bool ascending);
        Task AddAsync(TDomainEntity item);
        Task AddAsync(IEnumerable<TDomainEntity> items);
        Task RemoveAsync(TDomainEntity item);
        Task RemoveAsync(IEnumerable<TDomainEntity> items);
        Task RemoveAsync(TID id);
        Task RemoveAsync(IEnumerable<TID> ids);
        Task ModifyAsync(TDomainEntity item);
        Task ModifyAsync(IEnumerable<TDomainEntity> items);
    }
}
