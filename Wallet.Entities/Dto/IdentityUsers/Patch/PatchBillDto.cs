using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Entities.DataTransferObjects.IdentityUsers.Patch
{
    public class PatchBillDto
    {
        [Required(ErrorMessage = "Bill Name cannot be empty"), Display(Name = "Bill Name"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed")]
        public string BillName { get; set; }

        [Required(ErrorMessage = "Amount cannot be empty"), Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }
    }
}
