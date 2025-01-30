using System.Threading.Tasks;
using Wallet.Entities.Dto.Request;

namespace WalletApi.Authentication
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(LoginDto userForAuth);
        Task<string> CreateToken();
    }
}
