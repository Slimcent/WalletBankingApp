using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IStaffService
    {
        Task<string> CreateStaff(AddUserDto model);
        Task<string> UpdateStaff(Guid id, AddressRequestDto model);
        Task<IEnumerable<StaffResponseDto>> GetAllStaff();
        Task<StaffResponseDto> GetStaff(Guid id);
        IEnumerable<Staff> GetTotalNumberOfStaff();
    }
}
