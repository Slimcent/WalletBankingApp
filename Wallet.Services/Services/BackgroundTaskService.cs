using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.Models.Domain;
using Wallet.Logger;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class BackgroundTaskService : IHostedService, IDisposable
    {
        private readonly IRepository<User> _userRepo;
        private readonly IServiceFactory _serviceFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerMessage _logger;
        private Timer _timer;

        public BackgroundTaskService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _userRepo = _unitOfWork.GetRepository<User>();
            _logger = serviceFactory.GetServices<ILoggerMessage>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Schedule the task to run daily
            _timer = new Timer(DeleteUsersWithUnconfirmedEmail, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async void DeleteUsersWithUnconfirmedEmail(object state)
        {
            try
            {
                var now = DateTime.UtcNow;
                var threshold = now.AddDays(-14); // Two weeks ago

                // Query users with unconfirmed email older than two weeks
                var usersToDelete = (await _userRepo.GetByAsync(x => !x.EmailConfirmed && x.CreatedAt < threshold)).ToList();


                if (usersToDelete != null)
                {
                    _logger.LogInfo($"Found {usersToDelete.Count()} users to delete.");
                    await _userRepo.DeleteRangeAsync(usersToDelete);

                    _logger.LogInfo($"Deleted {usersToDelete.Count()} users.");
                }

                Serilog.Context.LogContext.PushProperty("AllRoles", usersToDelete, destructureObjects: true);
                Log.Information($"No users found");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
