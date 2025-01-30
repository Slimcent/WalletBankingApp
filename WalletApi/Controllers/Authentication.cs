using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.Models.Domain;
using Wallet.Logger;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;
using WalletApi.Authentication;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly ILoggerMessage _logger;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly IUserService _userService;

        public Authentication(ILoggerMessage logger, UserManager<User> userManager, IAuthenticationManager authManager, IUserService userService)
        {
            _logger = logger;
            _userManager = userManager;
            _authManager = authManager;
            _userService = userService;
        }

        [HttpPost("login", Name = "Login")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Login)}: Authentication failed. Invalid user name or password.");

                return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() });

            throw new Exception("Exception");
        }

        [HttpPost("create-user", Name = "Create-User")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto model)
        {
            string user = await _userService.CreateUser(model);

            return Ok(user);
        }


    }
}
