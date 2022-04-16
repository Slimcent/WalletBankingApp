using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.IdentityUsers.Request
{
    public class UserRoleDto
    {
        [Required(ErrorMessage = "UserName cannot be empty"), MinLength(2), MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Role Name cannot be empty"), MinLength(2), MaxLength(50)]
        public string Name { get; set; }
    }
}
