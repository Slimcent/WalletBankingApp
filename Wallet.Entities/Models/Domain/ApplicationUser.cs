using Microsoft.AspNetCore.Identity;
using System;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class ApplicationUser : IdentityUser, ITracker
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Active { get; set; }
        public int UserTypeId { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual UserType UserType { get; set; }
    }
}