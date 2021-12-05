using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.Data
{
    public class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
            new Role
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Role
            {
                Name = "Manager",
                NormalizedName = "MANAGER",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        } 
    }
}
