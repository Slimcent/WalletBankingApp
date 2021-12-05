using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.Transaction
{
    public class TransferDto
    {
        public decimal Amount { get; set; }

        [Display(Name = "Sender Wallet Account")]
        public string SenderWalletID { get; set; }

        [Display(Name = "Receiver Wallet Account")]
        public string ReceiverWalletID { get; set; }
    }
}
