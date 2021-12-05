using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Enumerators;

namespace Wallet.Entities.Models.Domain
{
    public class StampDutyCharge
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal StampDuty { get; set; }
        public string WalletId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
