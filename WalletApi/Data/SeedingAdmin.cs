using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Models.Context;
using Wallet.Entities.Models.Domain;

namespace WalletApi.Data
{
    public class SeedingAdmin
    {
        private readonly WalletDbContext _context;

        public SeedingAdmin(WalletDbContext context)
        {
            _context = context;
        }

        public async void SeedAdminUser()
        {
            var user = new User
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@email.com",
                NormalizedEmail = "admin@email.com",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<Role>(_context);

            if (!_context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new Role { Name = "admin", NormalizedName = "admin" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "password");
                user.PasswordHash = hashed;
                var userStore = new UserStore<User>(_context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "admin");
            }

            await _context.SaveChangesAsync();
        }


    }
}
