using System;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Enumerators;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.DataTransferObjects.Transaction.PostDto
{
    public class DepositTransactionDto
    {
        public TransactionType TransactionType { get; set; }
        public TransactionMode TransactionMode { get; set; }
        public string NetworkProvider { get; set; }
        public string BillName { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal StampDuty { get; set; }
        public string ReceiverWalletId { get; set; }
        public string SenderWalletId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
