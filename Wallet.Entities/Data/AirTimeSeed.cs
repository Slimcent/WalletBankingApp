using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.Data
{
    class AirTimeSeed : IEntityTypeConfiguration<AirTime>
    {
        public void Configure(EntityTypeBuilder<AirTime> builder)
        {
            builder.HasData(
            new AirTime
            {
                Id = Guid.Parse("1DA5EB5F-04CC-4F0E-AFA6-52B3C78BEDF9"),
                NetworkProvider = "Mtn",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new AirTime
            {
                Id = Guid.Parse("D584F98C-4A22-482D-BC9E-C1899AEDCC57"),
                NetworkProvider = "Airtel",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }
    }
}
