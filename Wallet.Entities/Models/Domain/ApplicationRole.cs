using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class ApplicationRole : IdentityRole, ITracker
    {
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}