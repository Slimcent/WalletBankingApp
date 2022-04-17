using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.Patch;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IRoleService
    {
        Task<string> CreateRole(RoleDto request);
        Task UpdateRole(string id, RoleDto request);
        Task<Response> EditRole(string Id, JsonPatchDocument<PatchRoleDto> model);
        Task<string> DeleteRole(RoleDto request);
        Task<string> AddUserToRole(UserRoleDto request);
        Task<string> RemoveUserFromRole(UserRoleDto request);
        Task<IList<string>> GetUserRoles(string userName);
        IEnumerable<Role> GetTotalNumberOfRoles();
        Task<IEnumerable<AllRolesDto>> GetAllRoles();
    }
}
