using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Request;
using Wallet.Entities.DataTransferObjects.Response;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;
using Wallet.Repository.Interfaces;
using Wallet.Services.Exceptions;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Transaction> _transactionRepo;
        private readonly IRepository<Bill> _billRepo;
        private readonly IRepository<Data> _dataRepo;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IRepository<Account> _accountRepo;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory, IMapper mapper)
        {
            _userManager = serviceFactory.GetServices<UserManager<User>>();
            _userRepo = unitOfWork.GetRepository<User>();
            _customerRepo = unitOfWork.GetRepository<Customer>();
            _accountRepo = unitOfWork.GetRepository<Account>();
            _transactionRepo = unitOfWork.GetRepository<Transaction>();
            _billRepo = unitOfWork.GetRepository<Bill>();
            _dataRepo = unitOfWork.GetRepository<Data>();
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

       
        public IEnumerable<Transaction> GetTotalNumberOfTransactions()
        {
            return _transactionRepo.GetAll();
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

        public async Task<UserClaimsResponseDto> CreateUserClaims(string email, string claimType, string claimValue)
        {
            var user = await _userManager.FindByEmailAsync(email.ToString().ToLower());
            if (user == null)
                throw new UserNotFoundException(email);

            Claim claim = new Claim(claimType, claimValue, ClaimValueTypes.String);

            IdentityResult result = await _userManager.AddClaimAsync(user, claim);

            if (result.Succeeded)
                return new UserClaimsResponseDto { ClaimType = claimType, ClaimValue = claimValue };

            var errorMessage = string.Empty;

            if (result.Errors.Any())
            {
                errorMessage = string.Join('\n', result.Errors);
            }

            throw new InvalidOperationException(errorMessage);
        }

        public async Task<string> DeleteClaims(UserClaimsRequestDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new UserNotFoundException(request.Email);

            var claim = new Claim(request.ClaimType, request.ClaimValue);

            IdentityResult result = await _userManager.RemoveClaimAsync(user, claim);

            if (result.Succeeded)
                return "User removed from claim successfully";

            var errorMessage = string.Empty;

            if (result.Errors.Any())
            {
                errorMessage = string.Join('\n', result.Errors);
            }

            throw new InvalidOperationException(errorMessage);
        }

        public async Task<EditUserClaimsDto> EditUserClaims(EditUserClaimsDto userClaimsDto)
        {
            var user = await _userManager.FindByEmailAsync(userClaimsDto.Email.ToString().Trim());
            if (user == null)
                throw new UserNotFoundException(userClaimsDto.Email);

            Claim newClaim = new(userClaimsDto.ClaimType.Trim().ToLower(), userClaimsDto.ClaimValue.Trim().ToLower());

            var oldClaim = new Claim(userClaimsDto.ClaimType.Trim().ToLower(), userClaimsDto.OldValue.Trim().ToLower());

            var result = await _userManager.ReplaceClaimAsync(user, oldClaim, newClaim);

            if (result.Succeeded)
                return new EditUserClaimsDto { Email = userClaimsDto.Email, ClaimType = userClaimsDto.ClaimType, ClaimValue = userClaimsDto.ClaimValue, OldValue = userClaimsDto.OldValue };


            var errorMessage = string.Empty;

            if (result.Errors.Any())
                errorMessage = string.Join('\n', result.Errors);

            throw new InvalidOperationException(errorMessage);
        }

        public async Task<IEnumerable<UserClaimsResponseDto>> GetUserClaims(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                throw new UserNotFoundException(email);

            var claim = await _userManager.GetClaimsAsync(user);

            var dto = claim.Select(x => new UserClaimsResponseDto
            {
                ClaimType = x.Type,
                ClaimValue = x.Value
            });

            return dto;
        }
    }
}
