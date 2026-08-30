using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Wallet.Entities.Models.Domain
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        public int TransactionTypeId { get; set; }
        public int TransactionModeId { get; set; }
        
        [Unicode(false)]
        [MaxLength(18)]
        public string? PhoneNumber { get; set; }
        public string? BillModeId { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal? StampDuty { get; set; }
        public string SenderAccount { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? StampDutyChargeId { get; set; }
        public bool Active { get; set; }
        public string WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual BillMode BillMode { get; set; }
        public virtual StampDutyCharge StampDutyCharge { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual TransactionMode TransactionMode { get; set; }
    }
}