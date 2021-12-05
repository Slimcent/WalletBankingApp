using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Models.Domain;
using Wallet.Repository.Interfaces;
using Wallet.Services.Interfaces;
using Wallet.Logger;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.GobalError;
using Wallet.Entities.Models.CustomerToUser;
using Wallet.Services.Helpers;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using System.Linq;

namespace Wallet.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Role> _roleRepo;
        private readonly IRepository<Transaction> _transactionRepo;
        private readonly IRepository<BillPayment> _billRepo;
        private readonly IRepository<AirTime> _airTimeRepo;
        private readonly IRepository<BuyData> _dataRepo;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IMapper _mapper;
        private readonly IServiceFactory _serviceFactory;

        private string Message { get; set; }


        public AdminService(UserManager<User> userManager, RoleManager<Role> roleManager, IUnitOfWork unitOfWork, 
            IServiceFactory serviceFactory, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepo = unitOfWork.GetRepository<User>();
            _roleRepo = unitOfWork.GetRepository<Role>();
            _customerRepo = unitOfWork.GetRepository<Customer>();
            _transactionRepo = unitOfWork.GetRepository<Transaction>();
            _billRepo = unitOfWork.GetRepository<BillPayment>();
            _airTimeRepo = unitOfWork.GetRepository<AirTime>();
            _dataRepo = unitOfWork.GetRepository<BuyData>();
            _serviceFactory = serviceFactory;
            _mapper = mapper;
        }

        public async Task<(IdentityResult, User)> Add(AddUserDto dto)
        {
            //var emailExists = await _userManager.FindByEmailAsync(dto.Email.ToLower().Trim());
            
            var password = "123456";
            //var user = _mapper.Map<User>(dto);
            var user = new User
            {
                FullName = $"{dto.FirstName} {dto.LastName}",
                UserName = dto.UserName,
                Email = dto.Email,
                EmailConfirmed = true
            };
                
            var result = await _userManager.CreateAsync(user, password);
            if (!_roleManager.RoleExistsAsync("Manager").Result)
            {
                var role = new Role
                {
                        Name = "Manager"
                };
                var roleResult = _roleManager.CreateAsync(role).Result;
                if (!roleResult.Succeeded)
                {
                    Message = "Error while creating Role";
                }
            }
            await _userManager.AddToRoleAsync(user, "Manager");
            return (result, user);            
        }

        public async Task<(IdentityResult, User)> CreateCustomerAsUser(IdentityModel model)
        {
            var user = new User
            {
                FullName = model.FullName,
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };
            var password = "123456";
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("Customer").Result)
                {
                    var role = new Role
                    {
                        Name = "Customer"
                    };
                    var roleResult = _roleManager.CreateAsync(role).Result;
                    if (!roleResult.Succeeded)
                    {
                        Message = "Error while creating Role";
                    }
                }
                await _userManager.AddToRoleAsync(user, "Customer");
            }
            return (result, user);
        }

        public async Task CreateCustomer(string userId)
        {
            
            var customer = new Customer
            {
                UserId = userId,
                
                Account = new Account()
                {
                    WalletID = WalletIdGenerator.GenerateWalletId(),
                    //CreatedBy = dto.FirstName,
                    Balance = 0,
                    IsActive = true,
                    UserId = userId
                }
            };
            await _customerRepo.AddAsync(customer);
        }

        public async Task<Response> AddRole(AddRoleDto model)
        {
            if (await _roleManager.RoleExistsAsync(model.Name.Trim().ToLower()))
                return new Response(false, "Role Already Exists");
           
            var role = new Role
            {
                Name = model.Name.Trim(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
                return new Response(true, $"Role with Name {model.Name} has been added Successful!");

            return new Response(false, $"Creating the Role {model.Name} failed!");
        }

        public async Task<Response> AddUserToRole(AddUserToRoleDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Email.Trim().ToLower());
            if(user == null)
                return new Response(false, "User does not Exist");

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            if (result.Succeeded)
                return new Response(true, $"{model.Email} has been added to the {model.RoleName} Successful!");

            return new Response(false, $"Adding {model.Email} to the Role {model.RoleName} failed!");
        }

        public async Task<Response> DeleteRole(string name)
        {
            //var role = _roleRepo.GetSingleByCondition(r => r.Name == name);
            var role = await _roleManager.FindByNameAsync(name.Trim().ToLower());
            if(role == null)
                return new Response(false, "Role does not Exist");

           _roleRepo.Delete(role);

            return new Response(true, $"Role, {role.Name} has been deleted successfully!");
        }

        public async Task<Response> AddBill(AddBillDto model)
        {
            var existingBill = _billRepo.GetSingleByCondition(b => b.BillName == model.BillName.Trim().ToLower());
            if(existingBill != null)
                return new Response(false, "Bill Name already Exist");

            var bill = new BillPayment
            {
                BillName = model.BillName,
                Amount = model.Amount,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _billRepo.AddAsync(bill);

            return new Response(true, $"Bill Name {model.BillName} and Amount {model.Amount} has been added Successfully!");
        }

        public async Task<Response> AddAirTime(AddNetworkProviderDto model)
        {
            var existingAirTime = _airTimeRepo.GetSingleByCondition(a => a.NetworkProvider == model.NetworkName.Trim().ToLower());
            if(existingAirTime != null)
                return new Response(false, "Network Provider name already Exist");

            var airTime = new AirTime
            {
                NetworkProvider = model.NetworkName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _airTimeRepo.AddAsync(airTime);

            return new Response(true, $"{model.NetworkName} has been added Successfully!");
        }

        public async Task<Response> AddData(AddNetworkProviderDto model)
        {
            var existingData = _dataRepo.GetSingleByCondition(predicate: d => d.NetworkProvider == model.NetworkName.Trim().ToLower());
            if(existingData != null)
                return new Response(false, "Network Provider name already Exist");

            var data = new BuyData
            {
                NetworkProvider = model.NetworkName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _dataRepo.AddAsync(data);

            return new Response(true, $"Network Provider Name {model.NetworkName} has been added Successfully!");
        }

        
        public string DeleteUser(string Id)
        {
            throw new NotImplementedException();
        }

        public string DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByID(object Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
