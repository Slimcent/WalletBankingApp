using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Entities.DataTransferObjects.Transaction
{
    public class TransferDto
    {
        [Required(ErrorMessage = "Amount cannot be empty"), Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = " Sender WalletID cannot be empty"), Display(Name = "Sender Wallet Account")]
        public string SenderWalletID { get; set; }

        [Required(ErrorMessage = " Receiver WalletID cannot be empty"), Display(Name = "Receiver Wallet Account")]
        public string ReceiverWalletID { get; set; }
    }
}
