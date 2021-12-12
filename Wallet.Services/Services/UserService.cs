using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;
using Wallet.Repository.Interfaces;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Role> _roleRepo;
        private readonly IRepository<Transaction> _transactionRepo;
        private readonly IRepository<BillPayment> _billRepo;
        private readonly IRepository<AirTime> _airTimeRepo;
        private readonly IRepository<BuyData> _dataRepo;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IRepository<Account> _accountRepo;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory, IMapper mapper)
        {
            
            _userRepo = unitOfWork.GetRepository<User>();
            _roleRepo = unitOfWork.GetRepository<Role>();
            _customerRepo = unitOfWork.GetRepository<Customer>();
            _accountRepo = unitOfWork.GetRepository<Account>();
            _transactionRepo = unitOfWork.GetRepository<Transaction>();
            _billRepo = unitOfWork.GetRepository<BillPayment>();
            _airTimeRepo = unitOfWork.GetRepository<AirTime>();
            _dataRepo = unitOfWork.GetRepository<BuyData>();
            _serviceFactory = serviceFactory;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AllUsersDto>> GetAllUsers()
        {
            var allUsers = await _userRepo.GetAllAsync();

            var userDto = _mapper.Map<IEnumerable<AllUsersDto>>(allUsers);

            return userDto;
        }

        

        public IEnumerable<User> GetTotalNumberOfUsers()
        {
            return _userRepo.GetAll();
        }

        public async Task<IEnumerable<AllTransactionsDto>> GetAllTransactions()
        {
            var allTransactions = await _transactionRepo.GetAllAsync();

            var transactionsDto = _mapper.Map<IEnumerable<AllTransactionsDto>>(allTransactions);

            return transactionsDto;
        }

        public async Task<IEnumerable<AllRolesDto>> GetAllRoles()
        {
            var allRoles = await _roleRepo.GetAllAsync();

            var rolesDto = _mapper.Map<IEnumerable<AllRolesDto>>(allRoles);

            return rolesDto;
        }

        public IEnumerable<Role> GetTotalNumberOfRoles()
        {
            return _roleRepo.GetAll();
        }

        public IEnumerable<Transaction> GetTotalNumberOfTransactions()
        {
            return _transactionRepo.GetAll();
        }

        public async Task<IEnumerable<AllBillsDto>> GetAllBills()
        {
            var allBills = await _billRepo.GetAllAsync();

            var billsDto = _mapper.Map<IEnumerable<AllBillsDto>>(allBills);

            return billsDto;
        }

        public IEnumerable<BillPayment> GetTotalNumberOfBills()
        {
            return _billRepo.GetAll();
        }

        public async Task<IEnumerable<AllAirTimeDto>> GetAllAirTime()
        {
            var allAirTime = await _airTimeRepo.GetAllAsync();

            var airTimeDto = _mapper.Map<IEnumerable<AllAirTimeDto>>(allAirTime);

            return airTimeDto;
        }

        public IEnumerable<AirTime> GetTotalNumberOfAirTime()
        {
            return _airTimeRepo.GetAll();
        }

        public async Task<IEnumerable<AllDataDto>> GetAllData()
        {
            var allData = await _dataRepo.GetAllAsync();

            var dataDto = _mapper.Map<IEnumerable<AllDataDto>>(allData);

            return dataDto;
        }

        public IEnumerable<BuyData> GetTotalNumberOfData()
        {
            return _dataRepo.GetAll();
        }
        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetSingleCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AllUsersDto> GetUserById(string id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            var userDto = _mapper.Map<AllUsersDto>(user);

            return userDto;
        }

        public async Task<AllUsersDto> GetUserByEmail(string email)
        {
            var user = _userRepo.GetSingleByCondition(e => e.Email == email);

            var userDto = _mapper.Map<AllUsersDto>(user);

            return userDto;
        }

        public async Task<Response> GetByUsernme(string username)
        {
            var user = _userRepo.GetSingleByCondition(u => u.UserName == username);

            if (user == null)
                return new Response(false, "User not found");

            return new Response(true, $"Full Name: {user.FullName} \nUsername : {user.UserName} \nEmail : {user.Email} " +
                $"\nCreated At : {user.CreatedAt} ");
        }

        public async Task<Response> GetUserByAccountNumber(string walletId)
        {
            var account = _accountRepo.GetSingleByCondition(a => a.WalletID == walletId);
            if (account == null)
                return new Response(false, "Account not found");

            var user = _userRepo.GetSingleByCondition(u => u.Id == account.UserId);
            if(user == null)
                return new Response(false, "User not found");

            return new Response(true, $"Account : {account.WalletID} \nFullName : {user.FullName} \nBalance : {account.Balance}" +
                $"\nIsActive : {account.IsActive} \nUserName : {user.UserName} \nEmail : {user.Email} ");
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepo.GetAllAsync();

            return customers;
        }

        public  async Task<IEnumerable<CustomerAccountDto>> GetCustomers()
        {
            var customers = await _customerRepo.GetAllAndInclude(c => c.User, c => c.Account);

            var dto = _mapper.Map<IEnumerable<CustomerAccountDto>>(customers);

            return dto;
        }
    }
}
