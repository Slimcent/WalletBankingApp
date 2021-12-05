using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Models.CustomerToUser;

namespace Wallet.Entities.DataTransferObjects
{
    public class AddCustomerDto
    {
        [Required(ErrorMessage = "First Name cannot be empty"), MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty"), MinLength(3), MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName cannot be empty"), MinLength(2), MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty"), EmailAddress]
        public string Email { get; set; }
    }
}
