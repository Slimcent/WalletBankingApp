using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Wallet.Entities.Models.Domain;
using Wallet.Repository.Interfaces;
using Wallet.Services.Interfaces;
using Wallet.Entities.DataTransferObjects;
using Wallet.Services.Helpers;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Microsoft.AspNetCore.JsonPatch;
using System.Security.Claims;

namespace Wallet.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Role> _roleRepo;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IMapper _mapper;
        private readonly IServiceFactory _serviceFactory;
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IServiceFactory serviceFactory)
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
                return  "customer already exists";

            User userNameExists = await _userManager.FindByNameAsync(model.UserName);
            if (userNameExists != null)
                return "Username already exists";

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

                Wallet = new Entities.Models.Domain.Wallet
                {
                    WalletNo = WalletIdGenerator.GenerateWalletId(),
                    Balance = 0,
                    IsActive = true,
                    CustomerId = user.Id,
                }
            };

            await _customerRepo.AddAsync(customer);
            var add = await _unitOfWork.SaveChangesAsync();

            if (add > 0) return "student created";
                       
            return $"Customer with email {model.Email} created successfully";
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

              
       

        public async Task<Response> DeleteUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email.Trim().ToLower());

            if (user is null)
                return new Response(false, "User does not Exist");

            await _userManager.DeleteAsync(user);

            return new Response(true, $"User with details below Deleted Successfully!\nFull Name : {user.FullName} \nUserName : {user.UserName} \nEmail : {user.Email} \nPhone Number : {user.PhoneNumber} ");
        }

        public async Task<Response> DeleteRoleByName(string name)
        {
            var role = await _roleManager.FindByNameAsync(name.Trim().ToLower());

            if (role is null)
                return new Response(false, "Role does not Exist");

            await _roleManager.DeleteAsync(role);

            return new Response(true, $"Role with Name {role.Name} has been deleted Successfully");
        }

        public Task<Response> DeleteUserById(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
