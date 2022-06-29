using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wallet.Entities.Data;
using Wallet.Entities.Interfaces;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.Models.Context
{
    public class WalletDbContext : IdentityDbContext<User, Role, string>
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new RoleSeed());
            //modelBuilder.ApplyConfiguration(new AirTimeSeed());
            //modelBuilder.ApplyConfiguration(new DataSeed());
            //modelBuilder.ApplyConfiguration(new BillPaymentSeed());

            modelBuilder.Entity<Staff>()
                .HasOne(a => a.Address)
                .WithOne(b => b.Staff)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasOne(a => a.Address)
                .WithOne(b => b.Customer)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is ITracker trackable)
                {
                    var now = DateTime.UtcNow;
                    //var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedAt = now;
                            //trackable.UpdatedBy = user;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.UpdatedAt = now;
                            //trackable.CreatedBy = user;
                            //trackable.UpdatedBy = user;
                            break;
                    }
                }
            }
        }


        public DbSet<Address> Address { get; set; }
        public DbSet<AirTime> AirTimes { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Data> Data { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Staff> StaffProfile { get; set; }
        public DbSet<StampDutyCharge> StampDutyCharges { get; set; }
        public DbSet<TransactionStampDutyCharge> TransactionStampDutyCharges { get; set; }
        public DbSet<Domain.Wallet> Wallets { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
    }
}
