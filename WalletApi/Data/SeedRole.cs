using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Models.Context;
using Wallet.Entities.Models.Domain;

namespace WalletApi.Data
{
    public static class SeedRole
    {
        private static RoleManager<Role> _roleManager;

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<WalletDbContext>();
            if ((await context.Database.GetPendingMigrationsAsync()).Any()) await context.Database.MigrateAsync();

            _roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<Role>>();

            await Create("SuperAdmin");
        }

        private static async Task Create(string name)
        {
            if (!await _roleManager.RoleExistsAsync(name))
            {
                var role = new Role { Name = name, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
                await _roleManager.CreateAsync(role);
            }
        }
    }
}
