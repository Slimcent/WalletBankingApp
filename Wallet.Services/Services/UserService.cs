﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Request;
using Wallet.Entities.DataTransferObjects.Response;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Exceptions;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Transaction> _transactionRepo;
        private readonly IRepository<Bill> _billRepo;
        private readonly IRepository<Entities.Models.Domain.Data> _dataRepo;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IRepository<Entities.Models.Domain.Wallet> _accountRepo;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory, IMapper mapper)
        {
            _userManager = serviceFactory.GetServices<UserManager<User>>();
            _roleManager = serviceFactory.GetServices<RoleManager<Role>>();
            _userRepo = unitOfWork.GetRepository<User>();
            _customerRepo = unitOfWork.GetRepository<Customer>();
            _accountRepo = unitOfWork.GetRepository<Entities.Models.Domain.Wallet>();
            _transactionRepo = unitOfWork.GetRepository<Transaction>();
            _billRepo = unitOfWork.GetRepository<Bill>();
            _dataRepo = unitOfWork.GetRepository<Entities.Models.Domain.Data>();
            _serviceFactory = serviceFactory;
            _mapper = mapper;
        }

        public async Task<string> CreateUser(AddUserDto model)
        {
            if (model == null)
                return "Invalid data sent";

            var existingEmail = await _userManager.FindByEmailAsync(model.Email.Trim().ToLower());
            if (existingEmail != null)
                throw new UserExistException(model.Email);

            var existingUserName = await _userManager.FindByNameAsync(model.UserName.Trim().ToLower());
            if (existingUserName != null)
                return "Username already exist";

            var user = _mapper.Map<User>(model);
            user.EmailConfirmed = true;

            var password = "123456";
            var res = await _userManager.CreateAsync(user, password);

            if (!res.Succeeded)
                throw new InvalidOperationException($"User creation failed");


            if (!_roleManager.RoleExistsAsync("Staff").Result)
            {
                var role = new Role { Name = "Staff" };
                var roleResult = _roleManager.CreateAsync(role).Result;
                if (!roleResult.Succeeded)
                    throw new InvalidOperationException($"Role creation failed");

            }
            await _userManager.AddToRoleAsync(user, "Staff");

            await CreateUserClaims(user.Email, ClaimTypes.Role, model.ClaimValue);

            return $"User with email {user.Email} created successfully";
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
            var user = await _userRepo.GetSingleByAsync(e => e.Email == email);

            var userDto = _mapper.Map<AllUsersDto>(user);

            return userDto;
        }

        public async Task<Response> GetByUsernme(string username)
        {
            var user = await _userRepo.GetSingleByAsync(u => u.UserName == username);

            if (user == null)
                return new Response(false, "User not found");

            return new Response(true, $"Full Name: \nUsername : {user.UserName} \nEmail : {user.Email} " +
                $"\nCreated At : {user.CreatedAt} ");
        }

        public async Task<Response> GetUserByAccountNumber(string walletId)
        {
            var account = await _accountRepo.GetSingleByAsync(a => a.WalletNo == walletId);
            if (account == null)
                return new Response(false, "Account not found");

            var user = _userRepo.GetSingleByAsync(u => u.Id == account.CustomerId.ToString());
            if (user == null)
                return new Response(false, "User not found");

            return new Response(true, $"Account : {account.WalletNo} \nFullName : \nBalance : {account.Balance}" +
                $"\nIsActive : {account.IsActive} \nUserName : \nEmail : ");
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepo.GetAllAsync();

            return customers;
        }

        public async Task<IEnumerable<CustomerAccountDto>> GetCustomers()
        {
            var customers = await _customerRepo.GetAllAndInclude(c => c.User, c => c.Wallet);

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
