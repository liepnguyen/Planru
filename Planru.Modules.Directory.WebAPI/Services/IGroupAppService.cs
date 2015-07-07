using Planru.Crosscutting.Data;
using Planru.Modules.Directory.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.WebAPI.Services
{
    public interface IGroupAppService
    {
        PageResult<GroupDTO> GetGroups<KProperty>(int pageNumber, int pageSize,
            Expression<Func<GroupDTO, KProperty>> orderByExpression, bool ascending);

        GroupDTO GetGroup(Guid id);

        void CreateGroup(GroupDTO groupDto);

        void DeleteGroup(Guid id);
    }
}
