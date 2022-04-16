using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.Transaction.PostDto
{
    public class AddNetworkProviderDto
    {
        [Required(ErrorMessage = "Network Name cannot be empty"), Display(Name = "Network Name"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name Format")]
        public string NetworkProvider { get; set; }
    }
}
