using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.IdentityUsers.Patch
{
    public class PatchDataDto
    {
        [Required(ErrorMessage = "Network Name cannot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed"), Display(Name = "Network Name")]
        public string NetworkProvider { get; set; }
    }
}
