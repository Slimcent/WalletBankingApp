using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.Transaction
{
    public class BuyDataDto
    {
        [Display(Name = "Network Provider")]
        public string NetworkProvider { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0]\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        public decimal Amount { get; set; }

        [Display(Name = "Wallet Account")]
        public string WalletId { get; set; }
    }
}
