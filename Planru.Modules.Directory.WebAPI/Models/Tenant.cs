using Planru.Modules.Directory.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.WebAPI.Models
{
    /// <summary>
    /// Represent for tenant model
    /// </summary>
    public class Tenant : TenantDTO
    {
        public Guid Id { get; set; }
    }
}
