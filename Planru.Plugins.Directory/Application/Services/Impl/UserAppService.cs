using Planru.Crosscutting.Adapter;
using Planru.Crosscutting.Common;
using Planru.Crosscutting.Data;
using Planru.Plugins.Directory.Application.DTOs;
using Planru.Plugins.Directory.Application.Services;
using Planru.Plugins.Directory.Domain.Entities;
using Planru.Plugins.Directory.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Application.Impl
{
    public class UserAppService : IUserAppService
    {
        private ITypeAdapter _typeAdapter;
        private IUserService _userService;

        public UserAppService(ITypeAdapter typeAdapter, IUserService userService)
        {
            _typeAdapter = typeAdapter;
            _userService = userService;
        }

        public void CreateUser(UserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(object id)
        {
            throw new NotImplementedException();
        }

        public PageResult<UserDTO> GetPaged<KProperty>(int pageNumber, int pageSize, Expression<Func<UserDTO, KProperty>> orderByExpression, bool ascending)
        {
            throw new NotImplementedException();
        }
    }
}
