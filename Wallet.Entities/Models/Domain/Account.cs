using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Account : ITracker
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(10), MinLength(10)]
        public string WalletID { get; set; }
        public string UserId { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Balance { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}
