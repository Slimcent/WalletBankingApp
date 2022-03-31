using System;
using System.ComponentModel.DataAnnotations;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.Dto.IdentityUsers.Request
{
    public class AddressRequestDto
    {
        [Required(ErrorMessage = "Plot Number cannot be empty")]
        public int PlotNo { get; set; }

        [Required(ErrorMessage = "Street Name cannot be empty"), MaxLength(20), MinLength(2)]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "City Name cannot be empty"), MaxLength(20), MinLength(2)]
        public string City { get; set; }

        [Required(ErrorMessage = "State Name cannot be empty"), MaxLength(20), MinLength(2)]
        public string State { get; set; }

        [Required(ErrorMessage = "Nationality cannot be empty"), MaxLength(20), MinLength(4)]
        public string Nationality { get; set; }
    }
}
