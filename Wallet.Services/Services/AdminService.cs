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
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Microsoft.AspNetCore.JsonPatch;

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
            var user = _mapper.Map<User>(dto);

            //var user = new User
            //{
            //    FullName = $"{dto.FirstName} {dto.LastName}",
            //    UserName = dto.UserName,
            //    Email = dto.Email,
            //    EmailConfirmed = true
            //};
                
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

            var roleDto = _mapper.Map<Role>(model);
           
            var result = await _roleManager.CreateAsync(roleDto);

            if (result.Succeeded)
                return new Response(true, $"Role with Name {model.Name} has been added Successful!");

            return new Response(false, $"Creating the Role {model.Name} failed!");
        }

        public async Task<Response> AddUserToRole(AddUserToRoleDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Email.Trim().ToLower());
            if(user == null)
                return new Response(false, "User does not Exist");

            var result = await _userManager.AddToRoleAsync(user, model.Name);

            if (result.Succeeded)
                return new Response(true, $"{model.Email} has been added to the {model.Name} Successful!");

            return new Response(false, $"Adding {model.Email} to the Role {model.Name} failed!");
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

            var billDto = _mapper.Map<BillPayment>(model);
                        
            await _billRepo.AddAsync(billDto);

            return new Response(true, $"Bill Name {model.BillName} and Amount {model.Amount} has been added Successfully!");
        }

        public async Task<Response> AddAirTime(AddNetworkProviderDto model)
        {
            var existingAirTime = _airTimeRepo.GetSingleByCondition(a => a.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if(existingAirTime != null)
                return new Response(false, "Network Provider name already Exist");

            var airTimeDdto = _mapper.Map<AirTime>(model);

            await _airTimeRepo.AddAsync(airTimeDdto);

            return new Response(true, $"{model.NetworkProvider} has been added Successfully!");
        }

        public async Task<Response> AddData(AddNetworkProviderDto model)
        {
            var existingData = _dataRepo.GetSingleByCondition(predicate: d => d.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if(existingData != null)
                return new Response(false, "Network Provider name already Exist");

            var dataDto = _mapper.Map<BuyData>(model);

            await _dataRepo.AddAsync(dataDto);

            return new Response(true, $"Network Provider Name {model.NetworkProvider} has been added Successfully!");
        }

        public async Task<Response> EditUser(string Id, JsonPatchDocument<PatchUserDto> model)
        {
            var user = await _userRepo.GetByIdAsync(Id);
            if (user == null)
                return new Response(false, $"User with ID {Id} not found");

            //var userDto = _mapper.Map<PatchUserDto>(user);

            var userDto = new PatchUserDto
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            model.ApplyTo(userDto);

            _mapper.Map(userDto, user);

            _userRepo.Update(user);

            return new Response(true, $"User Updated Successfully, see Details below\n Fullname : {user.FullName} \nUserName : {user.UserName} \nEmail : {user.Email} \nPhone Number : {user.PhoneNumber}");
        }

        public async Task<Response> EditRole(string Id, JsonPatchDocument<PatchRoleDto> model)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            if (role is null)
                return new Response(false, "Role does not exist");

            var roleDto = new PatchRoleDto
            {
                Name = role.Name
            };

            model.ApplyTo(roleDto);

            _mapper.Map(roleDto, role);

            await _roleManager.UpdateAsync(role);

            return new Response(true, $"Role Updated Successfully, see Details below\nRole Name : {role.Name}");
        }

        public async Task<Response> EditBill(Guid Id, JsonPatchDocument<PatchBillDto> model)
        {
            var bill = await _billRepo.GetByIdAsync(Id);

            if (bill is null)
                return new Response(false, "Bill does not Exist");

            var billDto = new PatchBillDto
            {
                BillName = bill.BillName,
                Amount = bill.Amount
            };

            model.ApplyTo(billDto);

            _mapper.Map(billDto, bill);

            _billRepo.Update(bill);

            return new Response(true, $"Bill Updated Successfully, see Details below\nBill Name : {bill.BillName} \nAmount : {bill.Amount}");
        }

        public async Task<Response> EditAirTime(Guid Id, JsonPatchDocument<PatchAirTimeDto> model)
        {
            var airTime = await _airTimeRepo.GetByIdAsync(Id);

            if (airTime is null)
                return new Response(false, "ArTime does not Exist");

            var airTimeDto = new PatchAirTimeDto
            {
                NetworkProvider = airTime.NetworkProvider
            };

            model.ApplyTo(airTimeDto);

            _mapper.Map(airTimeDto, airTime);

            _airTimeRepo.Update(airTime);

            return new Response(true, $"AirTime Updated Successfully, see Details below \nNetwork Name : {airTime.NetworkProvider}");
        }

        public async Task<Response> EditData(Guid Id, JsonPatchDocument<PatchDataDto> model)
        {
            var data = await _dataRepo.GetByIdAsync(Id);

            if (data is null)
                return new Response(false, "Data does not Exist");

            var dataDto = new PatchDataDto
            {
                NetworkProvider = data.NetworkProvider
            };

            model.ApplyTo(dataDto);

            _mapper.Map(dataDto, data);

            _dataRepo.Update(data);

            return new Response(true, $"Data Updated Successfully, see Details below \nNetwork Name : {data.NetworkProvider}");
        }

        public async Task<Response> DeleteUserByName(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return new Response(false, "User does not Exist");

            await _userManager.DeleteAsync(user);

            return new Response(true, $"User with details below Deleted Successfully!\nFull Name : {user.FullName} \nUserName : {user.UserName} \nEmail : {user.Email} \nPhone Number : {user.PhoneNumber} ");
        }

        public async Task<Response> DeleteRoleByName(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);

            if (role is null)
                return new Response(false, "Role does not Exist");

            await _roleManager.DeleteAsync(role);

            return new Response(true, $"Role with Name {role.Name} has been deleted Successfully");
        }

        public async Task<Response> DeleteBillByName(string name)
        {
            var bill = _billRepo.GetSingleByCondition(b => b.BillName == name);

            if (bill is null)
                return new Response(false, "Bill does not Exist");

            _billRepo.Delete(bill);

            return new Response(true, $"Bill with Name {bill.BillName} And Amount {bill.Amount} has been deleted Successfully");
        }

        public async Task<Response> DeleteAirTimeByName(string name)
        {
            var airTime = _airTimeRepo.GetSingleByCondition(a => a.NetworkProvider == name);

            if (airTime is null)
                return new Response(false, "AirTime does not Exist");

           _airTimeRepo.Delete(airTime);

            return new Response(true, $"Bill with Name {airTime.NetworkProvider} has been deleted Successfully");
        }

        public async Task<Response> DeleteDataByName(string name)
        {
            var data = _dataRepo.GetSingleByCondition(d => d.NetworkProvider == name);

            if (data is null)
                return new Response(false, "Data does not Exist");

            _dataRepo.Delete(data);

            return new Response(true, $"Bill with Name {data.NetworkProvider} has been deleted Successfully");
        }

        public Task<Response> DeleteUserById(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
