using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Modules.Directory.Application.Models
{
    /// <summary>
    /// Represent a tenant model contract
    /// </summary>
    public interface ITenant
    {
        /// <summary>
        /// Gets and sets the indentifer
        /// </summary>
        Guid Id { get; set; }
    }
}
