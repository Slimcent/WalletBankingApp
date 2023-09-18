using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Data.Implementation;
using Wallet.Data.Interfaces;
using Wallet.Entities.Models.Context;
using Wallet.Entities.Models.Domain;
using Wallet.Logger;
using Wallet.Services.Interfaces;
using Wallet.Services.Services;

namespace WalletApi.Middlewares
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        public static void ConfigureIISIntegration(this IServiceCollection services) => services.Configure<IISOptions>(options =>
        {
        });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerMessage, LoggerMessage>();


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IServiceFactory, ServiceFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork<WalletDbContext>>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAirTimeService, AirTimeService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IStaffService, StaffService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddScoped<BackgroundTaskService>();
            //services.AddHostedService<BackgroundTaskService>();
            
            return services;
        }


        public static IServiceCollection AddDBConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WalletDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WalletConnection"),
                     b => b.MigrationsAssembly("WalletApi")
                ));


            services.AddIdentity<User, Role>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = false;
                o.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<WalletDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            //var secretKey = Environment.GetEnvironmentVariable("SECRET");
            var secretKey = jwtSettings.GetSection("Secret").Value;
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }

    }
}
