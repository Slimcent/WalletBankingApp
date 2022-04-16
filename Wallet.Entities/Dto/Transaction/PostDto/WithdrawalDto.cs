using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Entities.Dto.Transaction.PostDto
{
    public class WithdrawalDto
    {
        [Required(ErrorMessage = "Amount cannot be empty"), Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "WalletID cannot be empty"), Display(Name = "Wallet Account")]
        public string WalletID { get; set; }
    }
}
