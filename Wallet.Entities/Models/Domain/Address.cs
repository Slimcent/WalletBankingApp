using System;
using System.ComponentModel.DataAnnotations;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Address : ITracker
    {
        [Key]
        public Guid Id { get; set; }
        public int? PlotNo { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Nationality { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? StaffId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Active { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }
    }
}