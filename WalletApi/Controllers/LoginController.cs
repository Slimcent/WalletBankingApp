using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.Models.Domain;
using Wallet.Logger;
using WalletApi.ActionFilters;
using WalletApi.Authentication;

namespace WalletApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoggerMessage _logger;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        public LoginController(ILoggerMessage logger, UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _logger = logger;
            _userManager = userManager;
            _authManager = authManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Invalid user name or password.");

                return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() });

            throw new Exception("Exception");
        }


    }
}
