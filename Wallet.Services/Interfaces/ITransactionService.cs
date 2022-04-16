using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Transaction.PostDto;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Response> Deposit(DepositDto model);
        Task<Response> Withdraw(WithdrawalDto model);
        Task<Response> Transfer(TransferDto model);
        Task<Response> PayBill(PayBillDto model);
        Task<Response> BuyData(BuyDataDto model);
        Task<Response> BuyAirTime(BuyAirTimeDto model);
        IEnumerable<Transaction> GetTramsctionByAUser(string id);
    }
}
