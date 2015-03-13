using Planru.Crosscutting.Data;
using Planru.Modules.Directory.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Application.Services
{
    /// <summary>
    /// Represent for a user application service contract
    /// </summary>
    public interface IUserAppService
    {
        /// <summary>
        /// Gets the users
        /// </summary>
        /// <typeparam name="KProperty">The type of key to order by</typeparam>
        /// <param name="pageNumber">The page number</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="orderByExpression">The orderby expression</param>
        /// <param name="ascending">Order by ascending if true and otherwise</param>
        /// <returns></returns>
        PageResult<UserDTO> GetUsers<KProperty>(int pageNumber, int pageSize,
            Expression<Func<UserDTO, KProperty>> orderByExpression, bool ascending);

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="userDto">The user data transfer object</param>
        void CreateUser(UserDTO userDto);

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="userDto">The user data transfer object</param>
        void UpdateUser(UserDTO userDto);
    }
}
