using Planru.Crosscutting.Data;
using Planru.Modules.Directory.WebAPI.Models;
using Planru.Modules.Directory.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Planru.Modules.Directory.WebAPI.Controllers
{
    [RoutePrefix("api/Group")]
    public class GroupController : ApiController
    {
        private IGroupAppService _groupAppService;

        public GroupController(IGroupAppService groupAppService)
        {
            if (groupAppService == null)
                throw new ArgumentNullException("groupAppService");

            this._groupAppService = groupAppService;
        }

        public PageResult<GroupDTO> Get(int? count, int? page)
        {
            int pageNumber = page ?? 0;
            int pageSize = count ?? 0;

            var result = this._groupAppService.GetGroups<string>(pageNumber, pageSize, k => k.Name, true);
            return result;
        }

        public IHttpActionResult Get(Guid id) 
        {
            var group = this._groupAppService.GetGroup(id);
            if (group == null)
                return NotFound();
            return Ok<GroupDTO>(group);
        }

        [Route("Members")]
        public IHttpActionResult GetMembers(Guid groupId)
        {
            return Ok<IEnumerable<UserDTO>>(new[] { new UserDTO() { DisplayName = "Liep Nguyen", Id = Guid.NewGuid() }, new UserDTO() { DisplayName = "Liep Nguyen", Id = Guid.NewGuid() } });
        }

        public IHttpActionResult Post(GroupDTO model)
        {
            this._groupAppService.CreateGroup(model);
            return Created<GroupDTO>(Url.Link("DefaultApi", new { id = model.Id }), model);
        }

        public void Delete(Guid id)
        {
            this._groupAppService.DeleteGroup(id);
        }
    }
}
