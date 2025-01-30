using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.Request
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "First Name canot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed"), MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "UserName canot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed"), MaxLength(50), MinLength(2)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email canot be empty"), EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
