using Planru.Core.Domain;
using Planru.Core.Domain.Specification;
using Planru.Crosscutting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence
{
    public interface IRepository<TEntity, TID> : IDisposable
    {
        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        void Add(TEntity item);

        /// <summary>
        /// Add items into repository
        /// </summary>
        /// <param name="items"></param>
        void Add(IEnumerable<TEntity> items);

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(TEntity item);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        void Remove(TID id);

        void Remove(IEnumerable<TEntity> items);

        void Remove(IEnumerable<TID> ids);

        /// <summary>
        /// Set item as modified
        /// </summary>
        /// <param name="item">Item to modify</param>
        void Modify(TEntity item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        void Modify(IEnumerable<TEntity> items);

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        TEntity Get(TID id);

        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Checks whether entity with provided id exists
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns>True/False</returns>
        bool Exists(TID id);

        /// <summary>
        /// Get all elements of type TEntity that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <returns></returns>
        IEnumerable<TEntity> AllMatching(ISpecification<TEntity> specification);

        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <param name="pageNumber">Page index</param>
        /// <param name="pageSize">Number of elements in each page</param>
        /// <param name="orderByExpression">Order by expression for this query</param>
        /// <param name="ascending">Specify if order is ascending</param>
        /// <returns>List of selected elements</returns>
        PageResult<TEntity> GetPaged<KProperty>(int pageNumber, int pageSize, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);

        /// <summary>
        /// Get  elements of type TEntity in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);

        long Count();
    }
}
