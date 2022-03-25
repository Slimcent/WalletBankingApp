using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Request;
using Wallet.Entities.Models.Domain;
using Wallet.Repository.Interfaces;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class RoleService : IRoleservice
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;
        private readonly IRepository<Role> _roleRepo;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _userManager = _serviceFactory.GetServices<UserManager<User>>();
            _roleManager = _serviceFactory.GetServices<RoleManager<Role>>();
            _roleRepo = _unitOfWork.GetRepository<Role>();
            _mapper = _serviceFactory.GetServices<IMapper>();
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

        public async Task EditRole(string id, RoleDto request)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                throw new InvalidOperationException($"Role with {id} not found");

            var roleUpdate = _mapper.Map(request, role);

            await _roleManager.UpdateAsync(roleUpdate);
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
