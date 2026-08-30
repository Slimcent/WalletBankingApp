using AutoMapper;
using System;
using System.Threading.Tasks;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;
using Wallet.Services.Helpers;
using Wallet.Data.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Wallet.Entities.Dto.Response;
using System.Collections.Generic;
using Wallet.Entities.Dto.Request;

namespace Wallet.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<ApplicationUser> _userRepo;
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
            _customerRepo = _unitOfWork.GetRepository<Customer>();
            _addressRepo = _unitOfWork.GetRepository<Address>();
            _userRepo = _unitOfWork.GetRepository<ApplicationUser>();
            _walletRepo = _unitOfWork.GetRepository<Entities.Models.Domain.Wallet>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }


        public async Task<string> CreateCustomer(UsersCreateRequestDto model)
        {
            CreateUserDto user = new()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                UserName = model.UserName,
                Role = model.Role,
            };
            string userId = await _serviceFactory.GetServices<IUserService>().CreateUser(user);

            Customer customer = new()
            {
                UserId = userId,
                PhoneNumber = model.PhoneNumber,
            };
            await _customerRepo.AddAsync(customer);

            await CreateCustomerAddress(customer);

            await CreateCustomerAccount(customer);

            return $"Customer with email {model.Email} was created successfully";
        }

        private async Task CreateCustomerAddress(Customer customer)
        {
            Address address = new() { UserId = customer.UserId};
            await _addressRepo.AddAsync(address);
        }

        private async Task CreateCustomerAccount(Customer customer)
        {
            Entities.Models.Domain.Wallet wallet = new()
            {
                WalletNumber = WalletIdGenerator.GenerateWalletId(),
                Balance = 0,
                Active = true,
            };
            await _walletRepo.AddAsync(wallet);
        }

        public async Task<string> DeleteCustomerById(Guid id)
        {
            Customer customer = await _customerRepo.GetByIdAsync(id);

            if (customer is null)
                return $"Customer with id {id} does not exist";

            await _customerRepo.DeleteAsync(customer);

            return $"Customer deleted successfully";
        }

        public async Task<string> UpdateCustomerAddress(string customerId, UpdateAddressDto model)
        {
            Address customer = await _addressRepo.GetSingleByAsync(x => x.UserId == customerId);
            if (customer == null)
                return $"Customer with id {customerId} does not exist";

            var update = _mapper.Map(model, customer);

            await _addressRepo.UpdateAsync(update);
            await _unitOfWork.SaveChangesAsync();

            return "Address updated successfully";
        }

        public async Task<string> PatchCustomerAddress(string userId, JsonPatchDocument<UpdateAddressDto> model)
        {
            Address customer = await _addressRepo.GetSingleByAsync(x => x.UserId == userId);

            if (customer == null)
                return $"Customer with id {userId} does not exist";

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

        public async Task<string> UpdateCustomer(string id, JsonPatchDocument<UpdateStaffDto> model)
        {
            Customer customer = await _customerRepo.GetSingleByAsync(s => s.Id == id,
                include: s => s.Include(u => u.User));

            if (customer == null)
                return $"staff with id {id} does not exist";

            UpdateStaffDto updateStaff = new()
            {
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
            IEnumerable<Customer> all = await _customerRepo.GetByAsync(x => x.Active == false,
                include: x => x.Include(u => u.User).Include(a => a.Address));

            return _mapper.Map<IEnumerable<CustomerResponseDto>>(all);
        }

        public async Task<CustomerResponseDto> GetCustomer(string id)
        {
            Customer customer = await _customerRepo.GetSingleByAsync(x => x.Id == id && x.Active == false,
                include: x => x.Include(x => x.Address).Include(x => x.User));

            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            return _mapper.Map<CustomerResponseDto>(customer);
        }

        public async Task<CustomerResponseDto> GetCustomerByEmail(string email)
        {
            ApplicationUser user = await _userRepo.GetSingleByAsync(u => u.Email == email && u.Customer.Active == false,
                include: u => u.Include(s => s.Customer).ThenInclude(a => a.Address)
                    .Include(x => x.Customer));

            if (user == null)
                throw new InvalidOperationException("User not found");

            return _mapper.Map<CustomerResponseDto>(user);
        }

        public async Task<string> SoftDeleteCustomer(string id)
        {
            Customer customer = await _customerRepo.GetSingleByAsync(x => x.Id == id);

            if (customer is null)
                return $"customer with Id {id} does not exist";

            customer.Active = true;
            
            await _customerRepo.UpdateAsync(customer);
            
            await _unitOfWork.SaveChangesAsync();

            return "Customer Deleted successfully";
        }

        public async Task<string> UnDeleteCustomer(string id)
        {
            Customer customer = await _customerRepo.GetSingleByAsync(x => x.Id == id);

            if (customer is null)
                return $"customer with Id {id} does not exist";

            customer.Active = false;
            
            await _customerRepo.UpdateAsync(customer);
            
            return "Customer UnDeleted successfully";
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetAllDeletedCustomers()
        {
            IEnumerable<Customer> all = await _customerRepo.GetByAsync(x => x.Active == true,
                include: x => x.Include(u => u.User).Include(a => a.Address));

            return _mapper.Map<IEnumerable<CustomerResponseDto>>(all);
        }

        public async Task<CustomerResponseDto> GetCustomerByWalletNo(string WalletNo)
        {
            Entities.Models.Domain.Wallet wallet = await _walletRepo.GetSingleByAsync(u => u.WalletNumber == WalletNo,
                 include: u => u.Include(e => e.User));

            if (wallet == null)
                throw new InvalidOperationException("User not found");

            return _mapper.Map<CustomerResponseDto>(wallet);
        }

        public Task<string> DeleteCustomerById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
