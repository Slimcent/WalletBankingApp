using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Enumerators;

namespace Wallet.Entities.Models.Domain
{
    public class TransactionStampDutyCharge
    {
        [Column(TypeName = "varchar(256)")]
        public string Id { get; set; }

        [Unicode(false)]
        [MaxLength(45)]
        public string UserId { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }
        public string StampDutyId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Active { get; set; }
        public string WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual StampDutyCharge StampDuty { get; set; }
    }
}