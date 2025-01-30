using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Entities.Dto.Request
{
    public class BuyAirTimeDto
    {
        [Required(ErrorMessage = "Network Name canot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed"), Display(Name = "Network Provider")]
        public string NetworkProvider { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0]\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Amount cannot be empty"), Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "WalletID cannot be empty"), Display(Name = "Wallet Account")]
        public string WalletId { get; set; }
    }
}
