using Planru.Plugins.Directory.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Application.Services
{
    public interface IUserAppService
    {
        void CreateUser(UserDTO userDto);
        void UpdateUser(UserDTO userDto);
        void DeleteUser(object id);
    }
}
