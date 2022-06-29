using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.PostDto;
using Wallet.Entities.Dto.Response;

namespace Wallet.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateUser(CreateUserDto model);
        Task<UserClaimsResponseDto> CreateUserClaims(string email, string claimType, string claimValue);
        Task<string> DeleteClaims(UserClaimsRequestDto request);
        Task<EditUserClaimsDto> EditUserClaims(EditUserClaimsDto userClaimsDto);
        Task<IEnumerable<UserClaimsResponseDto>> GetUserClaims(string email);
    }
}
