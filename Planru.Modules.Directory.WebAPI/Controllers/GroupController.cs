using Planru.Crosscutting.Data;
using Planru.Modules.Directory.Application.DTOs;
using Planru.Modules.Directory.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Planru.Modules.Directory.WebAPI.Controllers
{
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
