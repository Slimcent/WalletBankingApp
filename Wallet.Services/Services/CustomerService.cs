using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;
using Wallet.Entities.DataTransferObjects;
using Wallet.Services.Helpers;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Microsoft.AspNetCore.JsonPatch;
using System.Security.Claims;
using Wallet.Data.Interfaces;

namespace Wallet.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Role> _roleRepo;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IMapper _mapper;
        private readonly IServiceFactory _serviceFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _userManager = _serviceFactory.GetServices<UserManager<User>>();
            _roleManager = _serviceFactory.GetServices<RoleManager<Role>>();
            _roleRepo = _unitOfWork.GetRepository<Role>();
            _customerRepo = _unitOfWork.GetRepository<Customer>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }


        public async Task<string> CreateCustomer(AddUserDto model)
        {
            User emailExists = await _userManager.FindByEmailAsync(model.Email);
            if (emailExists != null)
                return  $"customer with email {model.Email} already exists";

            User userNameExists = await _userManager.FindByNameAsync(model.UserName);
            if (userNameExists != null)
                return $"Username {model.UserName} already exists";

            var user = _mapper.Map<User>(model);
            user.EmailConfirmed = true;

            var password = "123456";
            IdentityResult result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return "User creation failed";

            if (!_roleManager.RoleExistsAsync("Customer").Result)
            {
                Role role = new Role { Name = "Customer" };
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                if (!roleResult.Succeeded)
                    return "Error while creating role";
            }
            await _userManager.AddToRoleAsync(user, "Customer");

            await _serviceFactory.GetServices<IUserService>().CreateUserClaims(model.Email, ClaimTypes.Role, model.ClaimValue);

            Customer customer = new()
            {
                UserId = user.Id,
                PhoneNumber = model.MobileNo,
                FullName = $"{model.LastName} {model.FirstName}",
                Wallet = new Entities.Models.Domain.Wallet
                {
                    WalletNo = WalletIdGenerator.GenerateWalletId(),
                    Balance = 0,
                    IsActive = true,
                    CustomerId = Guid.Parse(user.Id)
                }
            };

            await _customerRepo.AddAsync(customer);
            var add = await _unitOfWork.SaveChangesAsync();

            if (add > 0) return "student created";
                       
            return $"Customer with email {model.Email} was created successfully";
        }
                
       
    }
}
