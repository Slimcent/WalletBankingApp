using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>, ITracker
    {
        public bool Active { get; set; } = true;

        [Unicode(false)]
        [MaxLength(36)]
        public string? MenuId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
