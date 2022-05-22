using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Enumerators;

namespace Wallet.Entities.Models.Domain
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionMode TransactionMode { get; set; }
        public string NetworkProvider { get; set; }
        public string BillName { get; set; }
        public string PhoneNumber { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal StampDuty { get; set; }
        public string ReceiverWalletId { get; set; }
        public string SenderWalletId { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid CustomerId { get; set; }
        public string StampDutyId { get; set; }

        //[ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
