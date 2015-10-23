using Planru.Core.Persistence;
using Planru.Crosscutting.Adapter;
using Planru.Plugins.Directory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Planru.Plugins.Directory.Domain.Services;
using Planru.Crosscutting.Data;
using Planru.Plugins.Directory.Application.DTOs;
using Planru.Plugins.Directory.Application.Services;

namespace Planru.Plugins.Directory.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserAppService _userAppService;
        private ITypeAdapter _typeAdapter;

        public UserController(ITypeAdapter typeAdapter, IUserAppService userService)
        {
            _typeAdapter = typeAdapter;
            _userAppService = userService;
        }

        public PageResult<UserDTO> Get(int? count, int? page)
        {
            var pageNumber = page ?? 0;
            var pageSize = count ?? 10;

            var pageResult = _userAppService.GetPaged(pageNumber, pageSize, o => o.Id, true)
                .ToPageResult<UserDTO>(_typeAdapter);

            return pageResult;
        }

        public IHttpActionResult Get(Guid id)
        {
            UserDTO user = null; // TODO: should be implemented
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
            _userAppService.DeleteUser(id);
        }
    }
}
