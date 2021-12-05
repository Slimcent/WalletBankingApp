using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.Transaction
{
    public class PayBillDto
    {
        public string Bill { get; set; }

        [Display(Name = "Wallet Account")]
        public string WalletId { get; set; }
    }
}
