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
    public interface IUserAppService
    {
        void CreateUser(UserDTO userDto);
        void UpdateUser(UserDTO userDto);
        void DeleteUser(object id);
        PageResult<UserDTO> GetPaged<KProperty>(int pageNumber, int pageSize, Expression<Func<UserDTO, KProperty>> orderByExpression, bool ascending);
    }
}
