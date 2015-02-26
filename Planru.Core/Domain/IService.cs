using Planru.Crosscutting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Domain
{
    public interface IService<TEntity, TID> : IDisposable
    {
        TEntity Get(TID id);
        IEnumerable<TEntity> GetAll();
        PageResult<TEntity> GetPaged<KProperty>(int pageNumber, int pageSize, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);
        void Add(TEntity item);
        void Add(IEnumerable<TEntity> items);
        void Remove(TEntity item);
        void Remove(IEnumerable<TEntity> items);
        void Remove(TID id);
        void Remove(IEnumerable<TID> ids);
        void Modify(TEntity item);
        void Modify(IEnumerable<TEntity> items);
        Task<TEntity> GetAsync(TID id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PageResult<TEntity>> GetPagedAsync<KProperty>(int pageNumber, int pageSize, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);
        Task AddAsync(TEntity item);
        Task AddAsync(IEnumerable<TEntity> items);
        Task RemoveAsync(TEntity item);
        Task RemoveAsync(IEnumerable<TEntity> items);
        Task RemoveAsync(TID id);
        Task RemoveAsync(IEnumerable<TID> ids);
        Task ModifyAsync(TEntity item);
        Task ModifyAsync(IEnumerable<TEntity> items);
    }
}
