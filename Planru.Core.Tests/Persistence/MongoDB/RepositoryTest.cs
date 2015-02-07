using Planru.Core.Domain;
using Planru.Core.Persistence;
using Planru.Core.Persistence.Annotations;
using Planru.Core.Persistence.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Tests.Persistence.MongoDB
{
    [Collection("mongo_repo_test")]
    public class MongoDMO : EntityDMO<Guid>
    {
        public string P1 { get; set; }
        public int P2 { get; set; }
    }

    public class Mongo : Entity<Guid>
    {
        public string P1 { get; set; }
        public int P2 { get; set; }
    }

    public class RepositoryTest
    {

    }
}
