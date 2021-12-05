//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WalletApi.Middlewares
//{
//    public class Hold
//    {
//        public async Task<Response> Deposit(DepositDto model)
//        {
//            var account = _accountRepo.GetSingleByCondition(a => a.WalletID == model.WalletID);
//            if (account == null)
//                return new Response(false, "Your Wallet is Invalid, Please visit the branch you opened your account for clarification");

//            if (!account.IsActive) return new Response(false, "Your Account is not Active for now");

//            if (model.Amount < 500) return new Response(false, "You cannot Deposit below 500");

//            account.Balance += model.Amount;

//            var debit = new Transaction()
//            {
//                Amount = model.Amount,
//                TimeStamp = DateTime.Now,
//                TransactionType = TransactionType.Credit,
//                //UserId = model.UserId
//            };
//            await _transactionRepo.AddAsync(debit);

//            return new Response(true, $"Your Deposit of {model.Amount} was Successful!");
//        }

//        [HttpPost("Deposit")]
//        [ServiceFilter(typeof(ModelStateValidation))]
//        public async Task<IActionResult> Deposit([FromBody] DepositDto model)
//        {
//            //var userId = await _userManager.FindByIdAsync(HttpContext.User.GetUserId());

//            var result = await _customerService.Deposit(model);

//            if (result.Success)
//                return Ok(result.Message);
//            return BadRequest(result.Message);
//        }
//    }
//}


//public async Task<(IdentityResult, User)> Add(AddUserDto dto)
//{
//    //var emailExists = await _userManager.FindByEmailAsync(dto.Email.ToLower().Trim());

//    var password = "123456";
//    //var user = _mapper.Map<User>(dto);
//    var user = new User
//    {
//        FullName = $"{dto.FirstName} {dto.LastName}",
//        UserName = dto.UserName,
//        Email = dto.Email,
//        EmailConfirmed = true
//    };

//    var result = await _userManager.CreateAsync(user, password);
//    if (!_roleManager.RoleExistsAsync("Manager").Result)
//    {
//        var role = new Role
//        {
//            Name = "Manager"
//        };
//        var roleResult = _roleManager.CreateAsync(role).Result;
//        if (!roleResult.Succeeded)
//        {
//            Message = "Error while creating Role";
//        }
//    }
//    await _userManager.AddToRoleAsync(user, "Manager");
//    return (result, user);
//}


//[HttpPost("Create User")]
//[ServiceFilter(typeof(ModelStateValidation))]
////[ServiceFilter(typeof(ExistingEmailValidation))]
//public async Task<IActionResult> CreateUser([FromBody] AddUserDto user)
//{
//    //var existingEmail = HttpContext.Items["email"] as User;

//    var result = await _adminService.Add(user);

//    if (!result.Item1.Succeeded)
//    {
//        foreach (var error in result.Item1.Errors)
//        {
//            ModelState.TryAddModelError(error.Code, error.Description);
//        }
//        return BadRequest(ModelState);
//    }

//    return Ok(new ErrorDetails { StatusCode = 200, Message = $"User, {user.UserName} was Created Successfully" });
//}
