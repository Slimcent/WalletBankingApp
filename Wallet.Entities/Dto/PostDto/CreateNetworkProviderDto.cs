using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.PostDto
{
    public class CreateNetworkProviderDto
    {
        [Required(ErrorMessage = "Network Name cannot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name Format")]
        public string NetworkProvider { get; set; }
    }
}
