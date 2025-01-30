using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Wallet.Entities.Data
{
    public class DataSeed : IEntityTypeConfiguration<Models.Domain.NetworkData>
    {
        public void Configure(EntityTypeBuilder<Models.Domain.NetworkData> builder)
        {
            builder.HasData(
            new Models.Domain.NetworkData
            {
                Id = Guid.Parse("CE185A95-533E-425C-ADF4-A5770766564B"),
                NetworkProvider = "Mtn",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Models.Domain.NetworkData
            {
                Id = Guid.Parse("9806F26B-E013-4DFF-812A-AFBA47D2FBE0"),
                NetworkProvider = "Airtel",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }
    }
}
