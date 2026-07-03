using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Entities.Models.Domain
{
    public class ProfilePicture
    {
        [Column(TypeName = "varchar(256)")]
        public string Id { get; set; }

        [Unicode(false)]
        [MaxLength(45)]
        public string UserId { get; set; }
        public string Picture { get; set; }
        public bool Active { get; set; }
        public ApplicationUser User { get; set; }
    }
}