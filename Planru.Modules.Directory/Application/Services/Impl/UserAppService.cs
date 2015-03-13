using Planru.Crosscutting.Common;
using Planru.Crosscutting.Data;
using Planru.Modules.Directory.Application.DTOs;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Domain.Repositories;
using Planru.Modules.Directory.Domain.Services;
using Planru.Crosscutting.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Application.Services.Impl
{
    /// <summary>
    /// Represent a user application service
    /// </summary>
    public class UserAppService : IUserAppService
    {
        private IUserService _userService;
        private IUserRepository _userRepository;

        /// <summary>
        /// Intializes for a new instance of the <see cref="UserAppService"/> class with the specified parameters.
        /// </summary>
        /// <param name="userService">The user service</param>
        /// <param name="userRepository">The user repository</param>
        public UserAppService(IUserService userService, IUserRepository userRepository)
        {
            if (userService == null)
                throw new ArgumentNullException("userService");
            if (userRepository == null)
                throw new ArgumentNullException("userRepository");

            this._userService = userService;
            this._userRepository = userRepository;
        }

        /// <inheritdoc />
        public PageResult<UserDTO> GetUsers<KProperty>(int pageNumber, int pageSize, 
            Expression<Func<UserDTO, KProperty>> orderByExpression, bool ascending)
        {
            var adaptedOrderExpression = ExpressionConverter<User>.Convert(orderByExpression);
            var result = _userRepository.GetPaged<KProperty>(pageNumber, pageSize, adaptedOrderExpression, ascending);
            return result.ToPageResult<UserDTO>();
        }

        /// <inheritdoc />
        public void CreateUser(UserDTO userDto)
        {
            var user = userDto.Adapt<User>();
            _userRepository.Add(user);
        }

        /// <inheritdoc />
        public void UpdateUser(UserDTO userDto)
        {
            var user = userDto.Adapt<User>();
            _userRepository.Modify(user);
        }
    }
}
