using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Enumerators;

namespace Wallet.Entities.Models.Domain
{
    public class TransactionStampDutyCharge
    {
        [Key]
        public Guid Id { get; set; }
        public TransactionMode TransactionMode { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal StampDuty { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}
