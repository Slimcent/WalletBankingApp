using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.PostDto;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Response;

namespace Wallet.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<string> CreateCustomer(UsersCreateRequestDto model);
        Task<string> DeleteCustomerById(Guid id);
        Task<string> UpdateCustomerAddress(Guid customerId, UpdateAddressDto model);
        Task<string> PatchCustomerAddress(Guid customerId, JsonPatchDocument<UpdateAddressDto> model);
        Task<string> UpdateCustomer(Guid id, JsonPatchDocument<UpdateStaffDto> model);
        Task<IEnumerable<CustomerResponseDto>> GetAllCustomers();
        Task<IEnumerable<CustomerResponseDto>> GetAllDeletedCustomers();
        Task<CustomerResponseDto> GetCustomer(Guid id);
        Task<CustomerResponseDto> GetCustomerByEmail(string email);
        Task<string> SoftDeleteCustomer(Guid id);
        Task<string> UnDeleteCustomer(Guid id);
        Task<CustomerResponseDto> GetCustomerByWalletNo(string WalletNo);
    }
}
