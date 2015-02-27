using MongoDB.Bson.Serialization;
using Planru.Core.Domain;
using Planru.Crosscutting.Adapter;
using Planru.Plugins.Directory.Domain;
using Planru.Plugins.Directory.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory
{
    public class Mappings : AdapterProfile
    {
        public override void Configure()
        {
            CreateMap<User, UserDTO>();

            BsonClassMap.RegisterClassMap<EntityAudit<Guid>>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(c => c.CreatedDateTime).SetElementName("created_date_time");
                cm.GetMemberMap(c => c.UpdatedDateTime).SetElementName("updated_date_time");
            });

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(c => c.FirstName).SetElementName("first_name");
                cm.GetMemberMap(c => c.LastName).SetElementName("last_name");
            });
        }
    }
}
