using System;
using System.ComponentModel.DataAnnotations;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Customer : ITracker
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual Address Address { get; set; }
    }
}
