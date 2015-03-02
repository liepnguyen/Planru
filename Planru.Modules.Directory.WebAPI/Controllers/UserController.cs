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
using Planru.Modules.Directory.Application.DTOs;
using Planru.Modules.Directory.Application.Services;

namespace Planru.Modules.Directory.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserAppService _userAppService;

        public UserController(IUserAppService userService)
        {
            _userAppService = userService;
        }

        public PageResult<UserDTO> Get(int? count, int? page)
        {
            var pageNumber = page ?? 0;
            var pageSize = count ?? 10;

            var pageResult = _userAppService.GetPaged(pageNumber, pageSize, o => o.UserName, true)
                .ToPageResult<UserDTO>();

            return pageResult;
        }

        public IHttpActionResult Get(Guid id)
        {
            UserDTO user = _userAppService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        public IHttpActionResult Post(UserDTO model)
        {
            _userAppService.CreateUser(model);
            return Created<UserDTO>(Url.Link("DefaultApi", new { id = model.Id }), model);
        }

        public void Put(UserDTO model)
        {

        }

        public void Delete(Guid id)
        {
            _userAppService.DeleteUserById(id);
        }
    }
}
