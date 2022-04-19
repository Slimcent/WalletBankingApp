using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;
using Wallet.Services.Helpers;
using System.Security.Claims;
using Wallet.Data.Interfaces;
using Wallet.Entities.Dto.IdentityUsers.PostDto;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Wallet.Entities.Dto.Response;
using System.Collections.Generic;

namespace Wallet.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IRepository<Address> _addressRepo;
        private readonly IRepository<Entities.Models.Domain.Wallet> _walletRepo;
        private readonly IMapper _mapper;
        private readonly IServiceFactory _serviceFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _userManager = _serviceFactory.GetServices<UserManager<User>>();
            _roleManager = _serviceFactory.GetServices<RoleManager<Role>>();
            _customerRepo = _unitOfWork.GetRepository<Customer>();
            _addressRepo = _unitOfWork.GetRepository<Address>();
            _userRepo = _unitOfWork.GetRepository<User>();
            _walletRepo = _unitOfWork.GetRepository<Entities.Models.Domain.Wallet>();
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
                LastName = model.LastName,
                FirstName = model.FirstName,
            };
            await _customerRepo.AddAsync(customer);
            var add = await _unitOfWork.SaveChangesAsync();
            if (add > 0) return "Customer created";

            Address address = new() { CustomerId = customer.Id };
            await _addressRepo.AddAsync(address);

            Entities.Models.Domain.Wallet wallet = new()
            {
                WalletNo = WalletIdGenerator.GenerateWalletId(),
                Balance = 0,
                IsActive = true,
                CustomerId = customer.Id
            };
            await _walletRepo.AddAsync(wallet);

            return $"Customer with email {model.Email} was created successfully";
        }

        public async Task<string> DeleteCustomerById(Guid id)
        {
            Customer customer = await _customerRepo.GetByIdAsync(id);

            if (customer is null)
                return $"Customer with id {id} does not exist";

            await _customerRepo.DeleteAsync(customer);

            return $"Customer deleted successfully";
        }

        public async Task<string> UpdateCustomerAddress(Guid customerId, UpdateAddressDto model)
        {
            Address customer = await _addressRepo.GetSingleByAsync(x => x.CustomerId == customerId);
            if (customer == null)
                return $"Customer with id {customerId} does not exist";

            var update = _mapper.Map(model, customer);

            await _addressRepo.UpdateAsync(update);
            await _unitOfWork.SaveChangesAsync();

            return "Address updated successfully";
        }

        public async Task<string> PatchCustomerAddress(Guid customerId, JsonPatchDocument<UpdateAddressDto> model)
        {
            Address customer = await _addressRepo.GetSingleByAsync(x => x.CustomerId == customerId);

            if (customer == null)
                return $"Customer with id {customerId} does not exist";

            UpdateAddressDto updateAddress = new()
            {
                PlotNo = customer.PlotNo,
                StreetName = customer.StreetName,
                City = customer.City,
                State = customer.State,
                Nationality = customer.Nationality,
            };

            model.ApplyTo(updateAddress);

            _mapper.Map(updateAddress, customer);

            await _addressRepo.UpdateAsync(customer);

            await _unitOfWork.SaveChangesAsync();

            return $"staff updated successfully";
        }

        public async Task<string> UpdateCustomer(Guid id, JsonPatchDocument<UpdateStaffDto> model)
        {
            Customer customer = await _customerRepo.GetSingleByAsync(s => s.Id == id,
                include: s => s.Include(u => u.User));

            if (customer == null)
                return $"staff with id {id} does not exist";

            UpdateStaffDto updateStaff = new()
            {
                LastName = customer.LastName,
                FirstName = customer.FirstName,
                Email = customer.User.Email,
                MobileNo = customer.PhoneNumber
            };

            //var updateStaff = _mapper.Map<UpdateStaffDto>(staff);

            model.ApplyTo(updateStaff);

            _mapper.Map(updateStaff, customer);

            _customerRepo.Update(customer);

            customer.User.NormalizedEmail = customer.User.Email.ToUpper();

            _userRepo.Update(customer.User);

            await _unitOfWork.SaveChangesAsync();

            return $"Customer with email {customer.User.Email} updated successfully";
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetAllCustomers()
        {
            IEnumerable<Customer> all = await _customerRepo.GetByAsync(x => x.IsDeleted == false,
                include: x => x.Include(u => u.User).Include(a => a.Address).Include(w => w.Wallet));

            return _mapper.Map<IEnumerable<CustomerResponseDto>>(all);
        }

        public async Task<CustomerResponseDto> GetCustomer(Guid id)
        {
            Customer customer = await _customerRepo.GetSingleByAsync(x => x.Id == id && x.IsDeleted == false, 
                include: x => x.Include(x => x.Address).Include(x => x.User).Include(x => x.Wallet));

            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            return _mapper.Map<CustomerResponseDto>(customer);
        }

        public async Task<CustomerResponseDto> GetCustomerByEmail(string email)
        {
            User user = await _userRepo.GetSingleByAsync(u => u.Email == email && u.Customer.IsDeleted == false,
                include: u => u.Include(s => s.Customer).ThenInclude(a => a.Address)
                    .Include(x => x.Customer).ThenInclude(x => x.Wallet));

            if (user == null)
                throw new InvalidOperationException("User not found");

            return _mapper.Map<CustomerResponseDto>(user);
        }

        public async Task<string> SoftDeleteCustomer(Guid id)
        {
            Customer customer = await _customerRepo.GetSingleByAsync(x => x.Id == id);

            if (customer is null)
                return $"customer with Id {id} does not exist";

            customer.IsDeleted = true;

            await _customerRepo.UpdateAsync(customer);

            await _unitOfWork.SaveChangesAsync();

            return "Customer Deleted successfully";
        }

        public async Task<string> UnDeleteCustomer(Guid id)
        {
            Customer customer = await _customerRepo.GetSingleByAsync(x => x.Id == id);

            if (customer is null)
                return $"customer with Id {id} does not exist";

            customer.IsDeleted = false;

            await _customerRepo.UpdateAsync(customer);

            await _unitOfWork.SaveChangesAsync();

            return "Customer UnDeleted successfully";
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetAllDeletedCustomers()
        {
            IEnumerable<Customer> all = await _customerRepo.GetByAsync(x => x.IsDeleted == true,
                include: x => x.Include(u => u.User).Include(a => a.Address).Include(w => w.Wallet));

            return _mapper.Map<IEnumerable<CustomerResponseDto>>(all);
        }

        public async Task<CustomerResponseDto> GetCustomerByWalletNo(string WalletNo)
        {
           Entities.Models.Domain.Wallet wallet = await _walletRepo.GetSingleByAsync(u => u.WalletNo == WalletNo,
                include: u => u.Include(s => s.Customer).ThenInclude(a => a.Address)
                .Include(e => e.Customer.User));

            if (wallet == null)
                throw new InvalidOperationException("User not found");

            return _mapper.Map<CustomerResponseDto>(wallet);
        }
    }
}
