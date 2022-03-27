using System;
using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.IdentityUsers.Patch
{
    public class PatchUserDto
    {
        [Required(ErrorMessage = "Name canot be empty"), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid Name Format"), MaxLength(50), MinLength(2)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "UserName cannot be empty"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name Format"),  MinLength(2), MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email canot be empty"), EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^[0]\d{10}$", ErrorMessage = "Invalid Phone Number"), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
