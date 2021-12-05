using Microsoft.AspNetCore.Identity;
using System;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class User : IdentityUser, ITracker
    {
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
