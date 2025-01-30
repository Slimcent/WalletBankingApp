using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.Request
{
    public class PayBillDto
    {
        [Required(ErrorMessage = "Bill Name cannot be empty"), Display(Name = "Bill Name")]
        public string Bill { get; set; }

        [Required(ErrorMessage = "WalletID cannot be empty"), Display(Name = "Wallet Account")]
        public string WalletId { get; set; }
    }
}
