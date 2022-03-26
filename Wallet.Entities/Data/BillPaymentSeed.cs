using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.Data
{
    class BillPaymentSeed : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasData(
            new Bill
            {
                Id = Guid.Parse("F1179901-AF52-4774-B8E5-76E76B55C8C5"),
                BillName = "DSTV",
                Amount = 6500,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Bill
            {
                Id = Guid.Parse("637C3058-F4C2-45AA-A30C-301CC5D2D101"),
                BillName = "GOTV",
                Amount = 3000,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }
    }
}
