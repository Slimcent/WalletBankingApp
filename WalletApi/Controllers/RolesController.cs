using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalMessage;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;

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
            await _roleService.UpdateRole(id, request);

            return Ok();
        }

        [HttpPatch("edit-role")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> EditRole(string Id, JsonPatchDocument<PatchRoleDto> model)
        {
            var role = await _roleService.EditRole(Id, model);

            if (role.Success)
                return Ok(role.Message);

            return BadRequest(role.Message);
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

        [HttpGet("all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var allRoles = await _roleService.GetAllRoles();

            if (allRoles.Any())
                return Ok(allRoles);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Roles found" });
        }

        [HttpGet("total-number-of-roles")]
        public IActionResult GetTotalNumberOfRoles()
        {
            var numberOfRoles = _roleService.GetTotalNumberOfRoles().Count();

            if (numberOfRoles <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Roles found" });

            return Ok($"{numberOfRoles} Roles");
        }
    }
}
