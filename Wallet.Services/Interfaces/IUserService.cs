using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Request;
using Wallet.Entities.DataTransferObjects.Response;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateUser(AddUserDto model);
        Task<UserClaimsResponseDto> CreateUserClaims(string email, string claimType, string claimValue);
        Task<string> DeleteClaims(UserClaimsRequestDto request);
        Task<EditUserClaimsDto> EditUserClaims(EditUserClaimsDto userClaimsDto);
        Task<IEnumerable<UserClaimsResponseDto>> GetUserClaims(string email);
    }
}
