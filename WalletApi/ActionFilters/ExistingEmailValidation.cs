using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Wallet.Entities.Models.Domain;
using Wallet.Logger;
using Wallet.Repository.Interfaces;

namespace WalletApi.ActionFilters
{
    public class ExistingEmailValidation : IAsyncActionFilter
    {
        private readonly IRepository<User> _userRepo;
        private readonly ILoggerMessage _logger;

        public ExistingEmailValidation(IUnitOfWork unitOfWork, ILoggerMessage logger)
        {
            _userRepo = unitOfWork.GetRepository<User>();
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var email = (string)context.ActionArguments["email"];
            var userEmail = _userRepo.Find(e => e.Email == email);
            if (userEmail != null)
            {
                _logger.LogInfo($"User with Email: {email} already exist in the database.");
                context.HttpContext.Items.Add("email", email);
                next();
            }
            
        }
        
    }
}
