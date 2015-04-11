﻿using Planru.Modules.Directory.Application.DTOs;
using Planru.Modules.Directory.Domain.Repositories;
using Planru.Modules.Directory.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Crosscutting.Adapter;
using Planru.Modules.Directory.Domain.Entities;
using Planru.Crosscutting.Data;
using System.Linq.Expressions;
using Planru.Crosscutting.Common;

namespace Planru.Modules.Directory.Application.Services.Internal
{
    public class GroupAppService : IGroupAppService
    {
        private IGroupService _groupService;
        private IGroupRepository _groupRepository;

        public GroupAppService(IGroupService groupService, IGroupRepository groupRepository)
        {
            if (groupService == null)
                throw new ArgumentNullException("groupService");
            if (groupRepository == null)
                throw new ArgumentNullException("groupRepository");

            this._groupService = groupService;
            this._groupRepository = groupRepository;
        }

        /// <inheritdoc />
        public PageResult<GroupDTO> GetGroups<KProperty>(int pageNumber, int pageSize,
            Expression<Func<GroupDTO, KProperty>> orderByExpression, bool ascending)
        {
            var adaptedOrderExpression = ExpressionConverter<Group>.Convert(orderByExpression);
            var result = this._groupRepository.GetPaged<KProperty>(pageNumber, pageSize, adaptedOrderExpression, ascending);
            return result.ToPageResult<GroupDTO>();
        }

        public void CreateGroup(GroupDTO groupDto)
        {
            var group = groupDto.Adapt<Group>();
            this._groupRepository.Add(group);
        }
    }
}
