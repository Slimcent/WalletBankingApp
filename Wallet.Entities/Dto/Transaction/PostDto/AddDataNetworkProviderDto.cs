using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.Transaction.PostDto
{
    public class AddDataNetworkProviderDto
    {
        [Required(ErrorMessage = "Network Name cannot be empty"), Display(Name = "Network Name"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed")]
        public string NetworkName { get; set; }
    }
}
