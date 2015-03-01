using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.Common;
using Planru.Crosscutting.Data;
using Planru.Modules.Directory.Application.DTOs;
using Planru.Modules.Directory.Application.Services;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Modules.Directory.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Application.Impl
{
    public class UserAppService : IUserAppService
    {
        private IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public void CreateUser(UserDTO userDto)
        {
            var user = userDto.Adapt<User>();
            _userService.Add(user);
        }

        public Task CreateUserAsync(UserDTO userDto)
        {
            var user = userDto.Adapt<User>();
            return _userService.AddAsync(user);
        }

        public void UpdateUser(UserDTO userDto)
        {
            var user = userDto.Adapt<User>();
            _userService.Modify(user);
        }

        public void DeleteUser(Guid id)
        {
            _userService.Remove(id);
        }

        public PageResult<UserDTO> GetPaged<KProperty>(int pageNumber, int pageSize, Expression<Func<UserDTO, KProperty>> orderByExpression, bool ascending)
        {
            var adaptedExpression = ExpressionConverter<User>.Convert(orderByExpression);
            var pageResult = _userService.GetPaged<KProperty>(pageNumber, pageSize, adaptedExpression, ascending);
            return pageResult.ToPageResult<UserDTO>();
        }
    }
}
