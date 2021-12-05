using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.Data
{
    public class DataSeed : IEntityTypeConfiguration<BuyData>
    {
        public void Configure(EntityTypeBuilder<BuyData> builder)
        {
            builder.HasData(
            new BuyData
            {
                Id = Guid.Parse("CE185A95-533E-425C-ADF4-A5770766564B"),
                NetworkProvider = "Mtn",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new BuyData
            {
                Id = Guid.Parse("9806F26B-E013-4DFF-812A-AFBA47D2FBE0"),
                NetworkProvider = "Airtel",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }
    }
}
