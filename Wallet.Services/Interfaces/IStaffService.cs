using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IStaffService
    {
        Task<string> CreateStaff(UsersCreateRequestDto model);
        Task<string> UpdateStaffAddress(string staffId, UpdateAddressDto model);
        Task<IEnumerable<StaffResponseDto>> GetAllStaff();
        Task<StaffResponseDto> GetStaff(string id);
        IEnumerable<Staff> GetTotalNumberOfStaff();
        Task<string> DeleteStaffById(string id);
        Task<StaffResponseDto> GetStaffByEmail(string email);
        Task<String> UpdateStaff(string id, JsonPatchDocument<UpdateStaffDto> model);
        Task<String> PatchStaffAddress(string staffId, JsonPatchDocument<UpdateAddressDto> model);
    }
}
