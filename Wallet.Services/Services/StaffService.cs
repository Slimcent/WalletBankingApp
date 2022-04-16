using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class StaffService : IStaffService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
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
            _userManager = _serviceFactory.GetServices<UserManager<User>>();
            _roleManager = _serviceFactory.GetServices<RoleManager<Role>>();
            _staffRepo = _unitOfWork.GetRepository<Staff>();
            _addressRepo = _unitOfWork.GetRepository<Address>();
            _userRepo = _unitOfWork.GetRepository<User>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }

        public async Task<string> CreateStaff(AddUserDto model)
        {
            User emailExists = await _userManager.FindByEmailAsync(model.Email);
            if (emailExists != null)
                return $"staff with email {model.Email} already exists";

            User userNameExists = await _userManager.FindByNameAsync(model.UserName);
            if (userNameExists != null)
                return $"Username {model.UserName} already exists";

            var user = _mapper.Map<User>(model);
            user.EmailConfirmed = true;

            var password = "123456";
            IdentityResult result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return "User creation failed";

            if (!_roleManager.RoleExistsAsync("Staff").Result)
            {
                Role role = new() { Name = "Staff" };
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                if (!roleResult.Succeeded)
                    return "Error while creating role";
            }
            await _userManager.AddToRoleAsync(user, "Staff");

            await _serviceFactory.GetServices<IUserService>().CreateUserClaims(model.Email, ClaimTypes.Role, model.ClaimValue);
           
            Staff staff = new()
            {
                UserId = user.Id,
                PhoneNumber = model.MobileNo,
                //FullName = $"{model.LastName} {model.FirstName}",
            };
            await _staffRepo.AddAsync(staff);

            var add = await _unitOfWork.SaveChangesAsync();
            if (add > 0) return "Staff created successfully";

            Address address = new() { StaffId = staff.Id };
            await _addressRepo.AddAsync(address);

            return $"Staff with email {model.Email} was created successfully";
        }

        public async Task<IEnumerable<StaffResponseDto>> GetAllStaff()
        { 
            var all = await _staffRepo.GetAllAndInclude(x => x.Address, x => x.User);

            var staff = all.Select(x => new StaffResponseDto
            {
                //FullName = x.FullName,
                Email = x.User.Email,
                PhoneNumber = x.PhoneNumber,
                Address = $" {x.Address.PlotNo} {x.Address.StreetName} {x.Address.State} ",
            });

            return staff;
        }

        public async Task<string> UpdateStaffAddress(Guid staffId, UpdateAddressDto model)
        {
            var staff = await _addressRepo.GetSingleByAsync(x => x.StaffId == staffId);

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

            return new StaffResponseDto
            {
                //FullName = staff.FullName,
                Email = staff.User.Email,
                PhoneNumber = staff.PhoneNumber,
                Address = $"{staff.Address.PlotNo} {staff.Address.StreetName} {staff.Address.State}, {staff.Address.Nationality}"
            };
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

            return $"Staff with name  deleted successfully";
        }

        public async Task<StaffResponseDto> GetStaffByEmail(string email)
        {
            User user = await _userRepo.GetSingleByAsync(u => u.Email == email, 
                include: u => u.Include(s => s.Staff).ThenInclude(a => a.Address));

            if (user == null)
                throw new InvalidOperationException("User not found");

            StaffResponseDto staff = new()
            {
                //FullName = user.Staff.FullName,
                Email = email,
                PhoneNumber = user.Staff.PhoneNumber,
                Address = $"{user.Staff.Address.PlotNo} {user.Staff.Address.StreetName} {user.Staff.Address.City} {user.Staff.Address.Nationality}"
            };

            return staff;
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
