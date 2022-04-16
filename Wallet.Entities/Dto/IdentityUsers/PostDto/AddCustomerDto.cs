using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.IdentityUsers.PostDto
{
    public class AddCustomerDto
    {
        [Required(ErrorMessage = "First Name cannot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed"), MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed"), MinLength(3), MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName cannot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed"), MinLength(2), MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty"), EmailAddress]
        public string Email { get; set; }
    }
}
