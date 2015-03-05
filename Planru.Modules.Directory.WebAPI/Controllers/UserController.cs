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

namespace Planru.Modules.Directory.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public PageResult<UserDTO> Get(int? count, int? page)
        {
            var pageNumber = page ?? 0;
            var pageSize = count ?? 10;

            var pageResult = _userService.GetPaged(pageNumber, pageSize, o => o.UserName, true)
                .ToPageResult<UserDTO>();

            return pageResult;
        }

        public IHttpActionResult Get(Guid id)
        {
            UserDTO user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        public IHttpActionResult Post(UserDTO model)
        {
            _userService.CreateUser(model);
            return Created<UserDTO>(Url.Link("DefaultApi", new { id = model.Id }), model);
        }

        public void Put(UserDTO model)
        {

        }

        public void Delete(Guid id)
        {
            _userService.DeleteUserById(id);
        }
    }
}
