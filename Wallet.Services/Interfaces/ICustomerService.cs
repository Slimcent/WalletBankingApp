using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.Dto.Response;

namespace Wallet.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<string> CreateCustomer(UsersCreateRequestDto model);
        Task<string> DeleteCustomerById(string id);
        Task<string> UpdateCustomerAddress(string customerId, UpdateAddressDto model);
        Task<string> PatchCustomerAddress(string customerId, JsonPatchDocument<UpdateAddressDto> model);
        Task<string> UpdateCustomer(string id, JsonPatchDocument<UpdateStaffDto> model);
        Task<IEnumerable<CustomerResponseDto>> GetAllCustomers();
        Task<IEnumerable<CustomerResponseDto>> GetAllDeletedCustomers();
        Task<CustomerResponseDto> GetCustomer(string id);
        Task<CustomerResponseDto> GetCustomerByEmail(string email);
        Task<string> SoftDeleteCustomer(string id);
        Task<string> UnDeleteCustomer(string id);
        Task<CustomerResponseDto> GetCustomerByWalletNo(string WalletNo);
    }
}
