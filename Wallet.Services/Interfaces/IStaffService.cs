using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto;
using Wallet.Entities.Dto.IdentityUsers.PostDto;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IStaffService
    {
        Task<string> CreateStaff(UsersCreateRequestDto model);
        Task<string> UpdateStaffAddress(Guid staffId, UpdateAddressDto model);
        Task<IEnumerable<StaffResponseDto>> GetAllStaff();
        Task<StaffResponseDto> GetStaff(Guid id);
        IEnumerable<Staff> GetTotalNumberOfStaff();
        Task<string> DeleteStaffById(Guid id);
        Task<StaffResponseDto> GetStaffByEmail(string email);
        Task<String> UpdateStaff(Guid id, JsonPatchDocument<UpdateStaffDto> model);
        Task<String> PatchStaffAddress(Guid staffId, JsonPatchDocument<UpdateAddressDto> model);
    }
}
