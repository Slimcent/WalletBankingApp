using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Request;

namespace Wallet.Services.Interfaces
{
    public interface IRoleService
    {
        Task<string> CreateRole(RoleDto request);
        Task EditRole(string id, RoleDto request);
        Task<string> DeleteRole(RoleDto request);
        Task<string> AddUserToRole(UserRoleDto request);
        Task<string> RemoveUserFromRole(UserRoleDto request);
        Task<IList<string>> GetUserRoles(string userName);
    }
}
