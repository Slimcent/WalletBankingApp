using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.Dto.IdentityUsers.PostDto;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> _staffRepo;
        private readonly IRepository<Address> _addressRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;
        private readonly IServiceFactory _serviceFactory;
        private readonly IUnitOfWork _unitOfWork;
       

        public StaffService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _staffRepo = _unitOfWork.GetRepository<Staff>();
            _addressRepo = _unitOfWork.GetRepository<Address>();
            _userRepo = _unitOfWork.GetRepository<User>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }

        public async Task<string> CreateStaff(UsersCreateRequestDto model)
        {
            AddUserDto user = new()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                UserName = model.UserName,
                Role = model.Role,
            };
            string userId = await _serviceFactory.GetServices<IUserService>().CreateUser(user);

            Staff staff = new()
            {
                UserId = userId,
                PhoneNumber = model.PhoneNumber,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Gender = model.Gender
            };
            await _staffRepo.AddAsync(staff);

            await CreateStaffAddress(staff);
            
            return $"Staff with email {model.Email} was created successfully";
        }

        private async Task CreateStaffAddress(Staff staff)
        {
            Address address = new() { StaffId = staff.Id };
            await _addressRepo.AddAsync(address);
        }
               
        public async Task<IEnumerable<StaffResponseDto>> GetAllStaff()
        { 
            var all = await _staffRepo.GetAllAndInclude(x => x.Address, x => x.User);

            return _mapper.Map<IEnumerable<StaffResponseDto>>(all);
        }

        public async Task<string> UpdateStaffAddress(Guid staffId, UpdateAddressDto model)
        {
            var staff = await _addressRepo.GetSingleByAsync(x => x.StaffId == staffId);
            if (staff == null)
                return $"staff with id {staffId} does not exist";

            var update = _mapper.Map(model, staff);
            await _addressRepo.UpdateAsync(update);
            await _unitOfWork.SaveChangesAsync();

            return "Address updated successfully";
        }

        public async Task<string> UpdateStaff(Guid id, JsonPatchDocument<UpdateStaffDto> model)
        {
            Staff staff = await _staffRepo.GetSingleByAsync(s => s.Id == id, 
                include: s => s.Include(u => u.User));

            if (staff == null)
                return $"staff with id {id} does not exist";

            UpdateStaffDto updateStaff = new()
            {
                LastName = staff.LastName,
                FirstName = staff.FirstName,
                Email = staff.User.Email,
                MobileNo = staff.PhoneNumber
            };

            //var updateStaff = _mapper.Map<UpdateStaffDto>(staff);

            model.ApplyTo(updateStaff);

            _mapper.Map(updateStaff, staff);

            _staffRepo.Update(staff);

            staff.User.NormalizedEmail = staff.User.Email.ToUpper();

            _userRepo.Update(staff.User);

            await _unitOfWork.SaveChangesAsync();

            return $"staff with email {staff.User.Email} updated successfully";
        }

        public async Task<StaffResponseDto> GetStaff(Guid id)
        {
            var staff = await _staffRepo.GetSingleByAsync(x => x.Id == id, include: x => x.Include(x => x.Address).Include(x => x.User));

            if (staff == null)
                throw new InvalidOperationException("Staff not found");

            return _mapper.Map<StaffResponseDto>(staff);
        }

        public IEnumerable<Staff> GetTotalNumberOfStaff()
        {
            return _staffRepo.GetAll();
        }

        public async Task<string> DeleteStaffById(Guid id)
        {
            Staff staff = await _staffRepo.GetByIdAsync(id);
            
            if (staff == null)
                return $"Staff with id {id} does not exist";

            await _staffRepo.DeleteAsync(staff);

            return $"Staff deleted successfully";
        }

        public async Task<StaffResponseDto> GetStaffByEmail(string email)
        {
            User user = await _userRepo.GetSingleByAsync(u => u.Email == email,
                include: u => u.Include(s => s.Staff).ThenInclude(a => a.Address));

            if (user == null)
                throw new InvalidOperationException("User not found");

            return _mapper.Map<StaffResponseDto>(user);
        }


        public async Task<string> PatchStaffAddress(Guid staffId, JsonPatchDocument<UpdateAddressDto> model)
        {
            var staff = await _addressRepo.GetSingleByAsync(x => x.StaffId == staffId);

            if (staff == null)
                return $"staff with id {staffId} does not exist";

            UpdateAddressDto updateAddress = new()
            {
                PlotNo = staff.PlotNo,
                StreetName = staff.StreetName,
                City = staff.City,
                State = staff.State,
                Nationality = staff.Nationality,
            };

            model.ApplyTo(updateAddress);

            _mapper.Map(updateAddress, staff);

            await _addressRepo.UpdateAsync(staff);

            await _unitOfWork.SaveChangesAsync();

            return $"staff updated successfully";
        }

    }
}
