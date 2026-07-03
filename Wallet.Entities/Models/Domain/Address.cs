using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Address : ITracker
    {
        [Column(TypeName = "varchar(256)")]
        public string Id { get; set; }

        [Unicode(false)]
        [MaxLength(45)]
        public string UserId { get; set; }
        public int? PlotNo { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Nationality { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Active { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}