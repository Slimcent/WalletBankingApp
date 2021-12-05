using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Entities.DataTransferObjects.Transaction
{
    public class AddBillDto
    {
        [Display(Name = "Bill Name"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name Format")]
        public string BillName { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }
    }
}
