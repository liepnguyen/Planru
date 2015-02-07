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

namespace Planru.Plugins.Directory.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService;
        private ITypeAdapter _typeAdapter;

        public UserController(ITypeAdapter typeAdapter, IUserService userService)
        {
            _typeAdapter = typeAdapter;
            _userService = userService;
        }

        public PageResult<UserDTO> Get(int? count, int? page)
        {
            var pageNumber = page ?? 0;
            var pageSize = count ?? 10;

            var pageResult = _userService.GetPaged(pageNumber, pageSize, o => o.Id, true)
                .ToPageResult<UserDTO>(_typeAdapter);

            return pageResult;
        }

        public IHttpActionResult Get(Guid id)
        {
            var user = _typeAdapter.Adapt<UserDTO>(_userService.Get(id));
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        public IHttpActionResult Post(UserDTO model)
        {
            return Created<UserDTO>(Url.Link("DefaultApi", new { id = model.Id }), null);
        }

        public void Put(UserDTO model)
        {

        }

        public void Delete(Guid id)
        {
            _userService.Remove(id);
        }
    }
}
