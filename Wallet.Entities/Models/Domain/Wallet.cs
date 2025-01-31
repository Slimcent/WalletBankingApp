using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Wallet : ITracker
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(10), MinLength(10)]
        public string WalletNo { get; set; }
        public Guid CustomerId { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Balance { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Customer Customer { get; set; }
    }
}