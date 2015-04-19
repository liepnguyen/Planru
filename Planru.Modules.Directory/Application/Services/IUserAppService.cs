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
    /// This is the contract that the application will interact to perform various operations for "users management".
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
        /// Gets all users of a group by group id.
        /// </summary>
        /// <typeparam name="KProperty"></typeparam>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        PageResult<UserDTO> GetUsersByGroupId<KProperty>(Guid groupId, int pageNumber, int pageSize,
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

        /// <summary>
        /// Deletes a user by id
        /// </summary>
        /// <param name="id">The unique identifer of a user</param>
        void DeleteUser(Guid id);
    }
}
