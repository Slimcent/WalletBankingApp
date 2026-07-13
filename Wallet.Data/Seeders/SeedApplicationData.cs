using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Data.Seeders;
using Wallet.Entities.Models.Context;
using Wallet.Entities.Models.Domain;

namespace WalletApi.Data.Seeders
{
    public static class SeedApplicationData
    {
        public static IServiceCollection BindSeedConfig(this IServiceCollection services, IConfiguration configuration)
        {
            Seed seed = new();

            configuration.GetSection("Seed").Bind(seed);

            services.AddSingleton(seed);

            return services;
        }

        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            Seed seed = scope.ServiceProvider.GetRequiredService<Seed>();
            WalletDbContext context = scope.ServiceProvider.GetRequiredService<WalletDbContext>();
            UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<ApplicationRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await context.Database.MigrateAsync();

            var strategy = context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                await using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    await SeedIfEmptyAsync(context.Genders, seed.Genders.Select(name => new Gender
                    {
                        Name = name,
                        Active = true,
                        CreatedBy = "seed",
                        UpdatedBy = "seed"
                    }),
                    context);

                    await SeedIfEmptyAsync(context.UserTypes, seed.UserTypes.Select(name => new UserType
                    {
                        Name = name,
                        Active = true,
                        CreatedBy = "seed",
                        UpdatedBy = "seed"
                    }),
                    context);

                    await SeedIfEmptyAsync(context.TransactionTypes, seed.TransactionTypes.Select(name => new TransactionType
                    {
                        Name = name,
                        Active = true,
                        CreatedBy = "seed",
                        UpdatedBy = "seed"
                    }),
                    context);

                    await SeedIfEmptyAsync(context.TransactionModes, seed.TransactionModes.Select(name => new TransactionMode
                    {
                        Name = name,
                        Active = true,
                        CreatedBy = "seed",
                        UpdatedBy = "seed"
                    }),
                    context);

                    await SeedIfEmptyAsync(context.Bills, seed.Bills.Select(bill => new Bill
                    {
                        Id = bill.Id,
                        Name = bill.Name,
                        Amount = bill.Amount,
                        Active = true,
                        CreatedBy = "seed",
                        UpdatedBy = "seed"
                    }),
                        context);

                    await SeedIfEmptyAsync(context.BillModes, seed.BillModes.Select(billMode => new BillMode
                    {
                        Id = billMode.Id,
                        Name = billMode.Name,
                        BillId = billMode.BillId,
                        Active = true,
                        CreatedBy = "seed",
                        UpdatedBy = "seed"
                    }),
                    context);

                    await SeedIfEmptyAsync(context.StampDutyCharges, seed.StampDutyCharges.Select(stampDutyCharge => new StampDutyCharge
                    {
                        Id = stampDutyCharge.Id,
                        Name = stampDutyCharge.Name,
                        Amount = stampDutyCharge.Amount,
                        Active = true
                    }),
                    context);

                    await SeedIfEmptyAsync(context.Menus, seed.Menus.Select(menu => new Menu
                    {
                        Id = menu.Id,
                        Name = menu.Name,
                        OrderId = menu.OrderId,
                        CreatedBy = "seed",
                        UpdatedBy = "seed"
                    }),
                    context);

                    await SeedRolesAsync(roleManager, seed);

                    await SeedAdminUserAsync(context, userManager, seed);

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        private static async Task SeedIfEmptyAsync<T>(DbSet<T> dbSet, IEnumerable<T> entities, WalletDbContext context) where T : class
        {
            if (await dbSet.AnyAsync())
                return;

            List<T> items = entities.ToList();

            if (!items.Any())
                return;

            await dbSet.AddRangeAsync(items);

            //await context.SaveChangesAsync();
        }

        private static async Task SeedRolesAsync(RoleManager<ApplicationRole> roleManager, Seed seed)
        {
            foreach (string role in seed.Roles)
            {
                if (await roleManager.RoleExistsAsync(role))
                    continue;

                ApplicationRole applicationRole = new ApplicationRole
                {
                    Name = role,
                    Active = true,
                    CreatedBy = "seed",
                    UpdatedBy = "seed"
                };

                IdentityResult result = await roleManager.CreateAsync(applicationRole);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(
                        string.Join(", ", result.Errors.Select(x => x.Description)));
                }
            }
        }

        private static async Task SeedAdminUserAsync(WalletDbContext context, UserManager<ApplicationUser> userManager, Seed seed)
        {
            if (await userManager.Users.AnyAsync())
                return;

            SeedAdminUser adminSeed = seed.AdminUser;

            UserType userType = await context.UserTypes.FirstOrDefaultAsync(x => x.Name == adminSeed.UserType);

            if (userType == null)
                throw new InvalidOperationException($"User type '{adminSeed.UserType}' was not found.");

            ApplicationUser user = new ApplicationUser
            {
                FirstName = adminSeed.FirstName,
                LastName = adminSeed.LastName,
                Email = adminSeed.Email,
                UserName = adminSeed.UserName,
                PhoneNumber = adminSeed.PhoneNumber,
                UserTypeId = userType.Id,
                Active = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedBy = "seed",
                UpdatedBy = "seed"
            };

            IdentityResult createUser = await userManager.CreateAsync(user, adminSeed.Password);

            if (!createUser.Succeeded)
            {
                throw new InvalidOperationException(
                    string.Join(", ", createUser.Errors.Select(x => x.Description)));
            }

            IdentityResult addToRole = await userManager.AddToRoleAsync(user, adminSeed.Role);

            if (!addToRole.Succeeded)
            {
                throw new InvalidOperationException(
                    string.Join(", ", addToRole.Errors.Select(x => x.Description)));
            }

            await SeedAdminStaffAsync(context, user, adminSeed);
        }

        private static async Task SeedAdminStaffAsync(WalletDbContext context, ApplicationUser user, SeedAdminUser adminSeed)
        {
            if (await context.Staff.AnyAsync(x => x.UserId == user.Id))
                return;

            Gender gender = await context.Genders.FirstOrDefaultAsync(x => x.Name == adminSeed.Gender);

            if (gender == null)
                throw new InvalidOperationException($"Gender '{adminSeed.Gender}' was not found.");

            context.Staff.Add(new Staff
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                Gender = gender,
                Active = true,
                CreatedBy = "seed",
                UpdatedBy = "seed"
            });

            await context.SaveChangesAsync();
        }
    }
}