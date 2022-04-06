using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Models.Domain;
using Wallet.Repository.Interfaces;
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
        private Guid id;

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
            
            //var staffId = await _staffRepo.GetSingleByAsync(x => x.Id == id && x.UserId == user.Id);
            //var addressId = await _addressRepo.GetSingleByAsync(x => x.Id == staffId.AddressId

            await _staffRepo.AddAsync(staff);
            //var add = await _unitOfWork.SaveChangesAsync();
            //if (add > 0) return "Staff created successfully";

            //Address address = new() { StaffId = staff.Id };
            //await _addressRepo.AddAsync(address);

            //staff.AddressId = address.Id;
                        

            //var addressId = await _addressRepo.GetByIdAsync(address.Id);

            return $"Staff with email {model.Email} was created successfully";
        }

        public Task<IEnumerable<StaffResponseDto>> GetAllStaff()
        {
            throw new NotImplementedException();
        }

        public async Task<StaffResponseDto> GetStaff(Guid id)
        {
            var staff = await _staffRepo.GetASingleByAsync(x => x.Id == id);
            throw new NotImplementedException();
        }

        public async Task<string> UpdateStaff(Guid id,AddressRequestDto model)
        {
            var staff = await _staffRepo.GetByIdAsync(id);

             Address address = new()
             {
                PlotNo = model.PlotNo,
                StreetName = model.StreetName,
                City = model.City,
                State = model.State,
                Nationality = model.Nationality,
                StaffId = staff.Id,
             };

             //staff.AddressId = address.Id;

            staff.Address = address;
            //staff.AddressId = id;

            await _addressRepo.AddAsync(address);

            var addressId = await _addressRepo.GetByIdAsync(address.Id);
            var staffAddressId = await _addressRepo.GetSingleByAsync(x => x.Id == addressId.Id);
                
             return "successful";
           

           
        }
    }
}
