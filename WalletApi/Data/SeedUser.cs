using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Wallet.Entities.Models.Context;
using Wallet.Entities.Models.Domain;

namespace WalletApi.Data
{
    public static class SeedUser
    {
        private const string AdminUser = "Dara";
        private const string AdminPassword = "123456";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            //var context = app.ApplicationServices
            //    .CreateScope().ServiceProvider
            //    .GetRequiredService<WalletDbContext>();
            //if ((await context.Database.GetPendingMigrationsAsync()).Any()) await context.Database.MigrateAsync();

            //var userManager = app.ApplicationServices
            //    .CreateScope().ServiceProvider
            //    .GetRequiredService<UserManager<User>>();

            //var user = await userManager.FindByNameAsync(AdminUser);
            //if (user != null) return;

            //user = new User
            //{ Email = "centpresley@gmail.com", UserName = "Dara", PhoneNumber = "070-323-1244", EmailConfirmed = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
            //var createUser = await userManager.CreateAsync(user, AdminPassword);

            //if (createUser.Succeeded) await userManager.AddToRoleAsync(user, "Manager");
        }
    }
}
