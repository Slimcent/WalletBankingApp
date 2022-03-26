using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<AllUsersDto>> GetAllUsers();
        IEnumerable<User> GetTotalNumberOfUsers();
        Task<AllUsersDto> GetUserById(string id);
        Task<AllUsersDto> GetUserByEmail(string email);
        Task<Response> GetByUsernme(string username);
        Task<Response> GetUserByAccountNumber(string walletId);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<IEnumerable<CustomerAccountDto>> GetCustomers();
        Task<IEnumerable<AllTransactionsDto>> GetAllTransactions();
        IEnumerable<Transaction> GetTotalNumberOfTransactions();       
        Task<IEnumerable<AllBillsDto>> GetAllBills();
        IEnumerable<BillPayment> GetTotalNumberOfBills();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetSingleCustomer(Guid id);
    }
}
