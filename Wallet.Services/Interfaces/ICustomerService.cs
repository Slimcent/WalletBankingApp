using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.GobalMessage;

namespace Wallet.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<string> CreateCustomer(AddUserDto model);
    }
}
