using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Enumerators;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Customer : ITracker
    {
        [Column(TypeName = "varchar(256)")]
        public string Id { get; set; }

        [Unicode(false)]
        [MaxLength(45)]
        public string UserId { get; set; }

        [Unicode(false)]
        [MaxLength(18)]
        public string PhoneNumber { get; set; }

        [Unicode(false)]
        [MaxLength(60)]
        public string Email { get; set; }
        public int GenderId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public Gender Gender { get; set; }
        public virtual Address Address { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}