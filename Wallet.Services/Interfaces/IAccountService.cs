using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountNumber(string accountNumber);
        Task<decimal> GetAccountBalance(string accountNumber);
                
        //Task<ViewAccountDto> GetByAccountNumber(string accountNumber);
    }
}
