using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Entities.Models.Context;

namespace Wallet.IntegrationTesting.Infrastructures
{
    public class WalletAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<WalletDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<WalletDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryEmployeeTest");
                });

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                using var appContext = scope.ServiceProvider.GetRequiredService<WalletDbContext>();
                try
                {
                    appContext.Database.EnsureCreated();
                    if (appContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                        appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }
            });
        }
    }
}
