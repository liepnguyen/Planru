using Planru.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Plugins.Directory.Domain.Entities
{
    public interface IUser : IEntity<Guid>
    {
        string UserPrincipalName { get; }
        string FirstName { get; }
        string LastNam { get; }
        string DisplayName { get; }
        string Email { get; }
    }
}
