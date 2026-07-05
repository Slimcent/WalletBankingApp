using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wallet.Entities.Interfaces;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.Models.Context
{
    public class WalletDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<AirTime> AirTimes { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<NetworkData> Data { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<StampDutyCharge> StampDutyCharges { get; set; }
        public DbSet<TransactionStampDutyCharge> TransactionStampDutyCharges { get; set; }
        public DbSet<Domain.Wallet> Wallets { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<BillMode> BillModes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<TransactionMode> TransactionModes { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {

                foreach (var property in entity.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        if (property.IsKey() || property.IsForeignKey() || property.IsIndex())
                        {
                            property.SetColumnType("varchar(256)");
                            continue;
                        }
                        else
                        {
                            property.SetColumnType("varchar(MAX)");
                        }
                    }
                }
            }
                        
            modelBuilder.Entity<ApplicationUserRole>(b =>
            {
                b.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .IsRequired();

                b.HasOne(x => x.Role)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRoleClaim>(b =>
            {
                b.HasOne(x => x.Role)
                    .WithMany(x => x.RoleClaims)
                    .HasForeignKey(x => x.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<ProfilePicture>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<NetworkData>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Address>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Bill>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AirTime>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Menu>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Customer>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Staff>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Domain.Wallet>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TransactionStampDutyCharge>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Transaction>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StampDutyCharge>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
