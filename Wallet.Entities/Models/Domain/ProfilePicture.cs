using System;
using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Models.Domain
{
    public class ProfilePicture
    {
        [Key]
        public Guid Id { get; set; }
        public string Picture { get; set; }
        public Guid UserId { get; set; }
    }
}
