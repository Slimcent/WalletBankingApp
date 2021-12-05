using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.IdentityUsers
{
    public class AddUserToRoleDto
    {
        [Required(ErrorMessage = "Role Name cannot be empty"), MinLength(2), MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name Format")]
        public string RoleName { get; set; }
        public string Email { get; set; }
    }
}
