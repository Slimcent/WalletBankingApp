using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.IdentityUsers.Patch
{
    public class PatchRoleDto
    {
        [Required(ErrorMessage = "Role Name cannot be empty"),  MinLength(2), MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed")]
        public string Name { get; set; }
    }
}
