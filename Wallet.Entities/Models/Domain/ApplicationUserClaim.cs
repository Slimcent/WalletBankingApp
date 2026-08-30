using Microsoft.AspNetCore.Identity;
using System;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class ApplicationUserClaim : IdentityUserClaim<string>, ITracker
    {
        public bool Active { get; set; }
        public string? MenuId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
