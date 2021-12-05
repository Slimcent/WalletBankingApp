using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;

namespace WalletApi.Authentication
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(LoginDto userForAuth);
        Task<string> CreateToken();
    }
}
