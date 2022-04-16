using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalMessage;
using Wallet.Services.Interfaces;

namespace WalletApi.Controllers
{
    [Route("api/claims")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IUserService _userService;

        public ClaimsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user-to-claims")]
        public async Task<IActionResult> AddUserToClaims(string email, string claimType, string claimValue)
        {
            var user = await _userService.CreateUserClaims(email, claimType, claimValue);

            return Ok(user);
        }

        [HttpPost("delete-claim")]
        public async Task<IActionResult> DeleteClaim(UserClaimsRequestDto request)
        {
            var user = await _userService.DeleteClaims(request);

            return Ok(user);
        }

        [HttpPost("edit-claim")]
        public async Task<IActionResult> EditClaim(EditUserClaimsDto editUserClaims)
        {
            var user = await _userService.EditUserClaims(editUserClaims);

            return Ok(user);
        }

        [HttpGet("get-user-claims")]
        public async Task<IActionResult> GetUserClaims(string email)
        {
            var userClaims = await _userService.GetUserClaims(email);

            if (userClaims.Any())
                return Ok(userClaims);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Claims found for user {email}" });
        }
    }
}
