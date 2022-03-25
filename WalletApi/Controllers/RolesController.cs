using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Request;
using Wallet.Services.Interfaces;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService) => _roleService = roleService;

        [HttpGet("get-user-roles")]
        public async Task<IActionResult> GetUserRoles([FromQuery] string userName)
        {
            var roles = await _roleService.GetUserRoles(userName);

            return Ok(roles);
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromQuery] RoleDto request)
        {
            var role = await _roleService.CreateRole(request);

            return Ok(role);
        }

        [HttpPut("update-role")]
        public async Task<IActionResult> UpdateRole(string id, RoleDto request)
        {
            await _roleService.EditRole(id, request);

            return Ok();
        }

        [HttpPost("add-user-to-role")]
        public async Task<IActionResult> AddUserToRole([FromQuery] UserRoleDto request)
        {
            var user = await _roleService.AddUserToRole(request);

            return Ok(user);
        }


        [HttpPost("remove-user-from-role")]
        public async Task<IActionResult> RemoveUserFromRole([FromQuery] UserRoleDto request)
        {
            var user = await _roleService.RemoveUserFromRole(request);

            return Ok(user);
        }

        [HttpDelete("delete-role")]
        public async Task<IActionResult> DeleteRole(RoleDto request)
        {
            var role = await _roleService.DeleteRole(request);

            return Ok(role);
        }
    }
}
