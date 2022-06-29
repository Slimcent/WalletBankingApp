using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.PostDto
{
    public class AddUserToRoleDto
    {
        [Required(ErrorMessage = "Role Name cannot be empty"), MinLength(2), MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email canot be empty"), EmailAddress]
        public string Email { get; set; }
    }
}
