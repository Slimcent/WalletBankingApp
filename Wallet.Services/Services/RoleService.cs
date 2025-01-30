using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;
using Wallet.Logger;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;
        private readonly IRepository<Role> _roleRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerMessage _logger;

        public RoleService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _userManager = _serviceFactory.GetServices<UserManager<User>>();
            _roleManager = _serviceFactory.GetServices<RoleManager<Role>>();
            _roleRepo = _unitOfWork.GetRepository<Role>();
            _mapper = _serviceFactory.GetServices<IMapper>();
            _logger = serviceFactory.GetServices<ILoggerMessage>();
        }

        public async Task<string> AddUserToRole(UserRoleDto request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName.Trim().ToLower());
            if (user == null)
                return $"User with email {request.UserName} does not Exist";

            var result = await _userManager.AddToRoleAsync(user, request.Name);

            if (!result.Succeeded)
                return $"Adding {request.UserName} to the Role {request.Name} failed!";

            return $"{request.UserName} has been added to the Role, {request.Name} Successful!";
        }

        public async Task<string> CreateRole(RoleDto request)
        {
            var roleExists = await _roleManager.FindByNameAsync(request.Name.Trim().ToLower());
            if (roleExists != null)
                throw new InvalidOperationException($"Role with name {request.Name} already exist");

            var roleToCreate = _mapper.Map<Role>(request);

            var result = await _roleManager.CreateAsync(roleToCreate);
            if (!result.Succeeded)
                throw new InvalidOperationException("Role creation failed");

            return $"Role with name {request.Name} created successfully";
        }

        public async Task<string> DeleteRole(RoleDto request)
        {
            var role = await _roleManager.FindByNameAsync(request.Name.Trim().ToLower());

            if (role is null)
                return $"Role {request.Name} does not Exist";

            await _roleManager.DeleteAsync(role);

            return $"Role with Name {role.Name} has been deleted Successfully";
        }

        public async Task UpdateRole(string id, RoleDto request)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                throw new InvalidOperationException($"Role with {id} not found");

            var roleUpdate = _mapper.Map(request, role);

            await _roleManager.UpdateAsync(roleUpdate);
        }

        public async Task<Response> EditRole(string Id, JsonPatchDocument<PatchRoleDto> model)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            if (role is null)
                return new Response(false, "Role does not exist");

            var roleDto = new PatchRoleDto
            {
                Name = role.Name
            };

            model.ApplyTo(roleDto);

            _mapper.Map(roleDto, role);

            await _roleManager.UpdateAsync(role);

            return new Response(true, $"Role Updated Successfully, see Details below\nRole Name : {role.Name}");
        }

        public async Task<IEnumerable<RoleResponseDto>> GetAllRoles()
        {
            var allRoles = await _roleRepo.GetAllAsync();

            var rolesDto = _mapper.Map<IEnumerable<RoleResponseDto>>(allRoles);
                        
            Serilog.Context.LogContext.PushProperty("AllRoles", rolesDto, destructureObjects: true);
            Log.Information($"Got all {rolesDto.Count()} roles Successful");

            return rolesDto;
        }

        public IEnumerable<Role> GetTotalNumberOfRoles()
        {
            return _roleRepo.GetAll();
        }

        public async Task<IList<string>> GetUserRoles(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName.Trim().ToLower());
            if (user == null)
                throw new InvalidOperationException($"User with userName {userName} not found");

            List<string> userRoles = (List<string>)await _userManager.GetRolesAsync(user);
            if (!userRoles.Any())
                throw new InvalidOperationException($"user {userName} has no role");

            return userRoles;
        }

        public async Task<string> RemoveUserFromRole(UserRoleDto request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName.Trim().ToLower());
            if (user == null)
                return $"User with email {request.UserName} does not Exist";

            List<string> userRoles = (List<string>)await _userManager.GetRolesAsync(user);
            var roleToRemove = userRoles.FirstOrDefault(role => role.Equals(request.Name, StringComparison.InvariantCultureIgnoreCase));

            if (roleToRemove == null)
                return $"User not in {request.Name} Role";

            var result = await _userManager.RemoveFromRoleAsync(user, roleToRemove);
            if (!result.Succeeded)
                return $"failed to remove {request.UserName} from Role {request.Name}";

            return $"{request.UserName} removed from Role {request.Name} successfully";
        }
    }
}
