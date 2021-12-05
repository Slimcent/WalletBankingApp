using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.Transaction
{
    public class WithdrawalDto
    {
        public decimal Amount { get; set; }

        [Display(Name = "Wallet Account")]
        public string WalletID { get; set; }
    }
}
