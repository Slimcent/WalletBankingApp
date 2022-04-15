using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
                FullName = $"{model.LastName} {model.FirstName}",
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
                FullName = x.FullName,
                Email = x.User.Email,
                PhoneNumber = x.PhoneNumber,
                Address = $" {x.Address.PlotNo} {x.Address.StreetName} {x.Address.State} ",
            });

            return staff;
        }

        public async Task<string> UpdateStaff(Guid id, AddressRequestDto model)
        {
            var staff = await _addressRepo.GetSingleByAsync(x => x.StaffId == id);

            var update = _mapper.Map(model, staff);
            await _addressRepo.UpdateAsync(update);
            await _unitOfWork.SaveChangesAsync();

            return "Success";
        }

        public async Task<StaffResponseDto> GetStaff(Guid id)
        {
            var staff = await _staffRepo.GetSingleByAsync(x => x.Id == id, include: x => x.Include(x => x.Address).Include(x => x.User));

            if (staff == null)
                throw new InvalidOperationException("Staff not found");

            return new StaffResponseDto
            {
                FullName = staff.FullName,
                Email = staff.User.Email,
                PhoneNumber = staff.PhoneNumber,
                Address = $"{staff.Address.PlotNo} {staff.Address.StreetName} {staff.Address.State}, {staff.Address.Nationality}"
            };
        }

        public IEnumerable<Staff> GetTotalNumberOfStaff()
        {
            return _staffRepo.GetAll();
        }


    }
}
