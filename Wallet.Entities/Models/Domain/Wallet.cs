using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Wallet : ITracker
    {
        [Column(TypeName = "varchar(256)")]
        public string Id { get; set; }

        [MaxLength(10), MinLength(10)]
        public string WalletNumber { get; set; }

        [Unicode(false)]
        [MaxLength(45)]
        public string? UserId { get; set; }
        
        [Column(TypeName = "decimal(38,2)")]
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Active { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<StampDutyCharge> StampDutyCharges { get; set; }
        public virtual ICollection<TransactionStampDutyCharge> TransactionStampDutyCharges { get; set; }
    }
}