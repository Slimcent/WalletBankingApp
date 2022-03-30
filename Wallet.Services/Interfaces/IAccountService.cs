using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Entities.Models.Domain.Wallet>> GetAccounts();
        Task<Entities.Models.Domain.Wallet> GetAccountNumber(string accountNumber);
        Task<decimal> GetAccountBalance(string accountNumber);
                
        //Task<ViewAccountDto> GetByAccountNumber(string accountNumber);
    }
}
