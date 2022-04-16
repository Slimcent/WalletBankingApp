using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.PostDto;

namespace Wallet.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<string> CreateCustomer(AddUserDto model);
    }
}
