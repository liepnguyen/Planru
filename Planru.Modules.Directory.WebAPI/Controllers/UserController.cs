using Planru.Core.Persistence;
using Planru.Crosscutting.Adapter;
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
using Planru.Modules.Directory.Application.DTOs;

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
            int pageNumber = page ?? 0;
            int pageSize = count ?? 0;

            var result = _userService.GetUsers<string>(pageNumber, pageSize, k => k.Firstname, true);
            return result;
        }

        public IHttpActionResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Post(UserDTO model)
        {
            _userService.UpdateUser(model);
            return Created<UserDTO>(Url.Link("DefaultApi", new { id = model.Id }), model);
        }

        public void Put(UserDTO model)
        {
            
        }

        public void Delete(Guid id)
        {
            _userService.DeleteUser(id);
        }
    }
}
