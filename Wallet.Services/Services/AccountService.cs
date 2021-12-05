using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Models.Domain;
using Wallet.Repository.Interfaces;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class AccountService : IAccountService
    {
        
        private readonly IRepository<Account> _accountRepo;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _accountRepo = unitOfWork.GetRepository<Account>();
        }

        public Task<decimal> GetAccountBalance(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetAccountNumber(string accountNumber)
        {
            var acconut = _accountRepo.GetSingleByCondition(a => a.WalletID == accountNumber);

            return acconut;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var allAccounts = await _accountRepo.GetAllAsync();

            return allAccounts;
            
        }

        //public IEnumerable<Account> GetAccountsAndUser()
        //{
        //    var allAccounts = _accountRepo.GetAll.Include(a => a.);

        //    return allAccounts;

        //}


        //public async Task<ViewAccountDto> GetByAccountNumber(string accountNumber)
        //{
        //    Account customerAccount = _accountRepo.GetByCondition(x => x.Number == accountNumber, includeProperties: "Customers").FirstOrDefault();
        //    return _mapper.Map<ViewAccountDto>(customerAccount);
        //}
    }
}
