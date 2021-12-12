using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.Transaction
{
    public class AddDataNetworkProviderDto
    {
        [Required(ErrorMessage = "Network Name cannot be empty"), Display(Name = "Network Name"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed")]
        public string NetworkName { get; set; }
    }
}
