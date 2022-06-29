using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.IdentityUsers.Patch
{
    public class PatchNetworkProviderDto
    {
        [Required(ErrorMessage = "Network Name cannot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed")]
        public string NetworkProvider { get; set; }
    }
}
