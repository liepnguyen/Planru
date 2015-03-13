using Planru.Core.Persistence;
using Planru.Crosscutting.Adapter;
using Planru.Modules.Directory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Planru.Modules.Directory.Domain.Services;
using Planru.Crosscutting.Data;
using Planru.Modules.Directory.Application.Services;
using Planru.Modules.Directory.Application.Models;

namespace Planru.Modules.Directory.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserAppService _userService;

        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }

        public PageResult<UserDTO> Get(int? count, int? page)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Post(UserDTO model)
        {
            throw new NotImplementedException();
        }

        public void Put(UserDTO model)
        {

        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
