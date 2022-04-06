using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class AccountService : IAccountService
    {
        
        private readonly IRepository<Entities.Models.Domain.Wallet> _accountRepo;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _accountRepo = unitOfWork.GetRepository<Entities.Models.Domain.Wallet>();
        }

        public Task<decimal> GetAccountBalance(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Models.Domain.Wallet> GetAccountNumber(string accountNumber)
        {
            throw new NotImplementedException();
        }

        //public async Task<Entities.Models.Domain.Wallet> GetAccountNumber(string accountNumber)
        //{
        //    var acconut = _accountRepo.GetSingleByAsync(a => a.WalletNo == accountNumber);

        //    return acconut;
        //}

        public async Task<IEnumerable<Entities.Models.Domain.Wallet>> GetAccounts()
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
