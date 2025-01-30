using System;
using System.ComponentModel.DataAnnotations;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Data : ITracker
    {
        [Key]
        public Guid Id { get; set; }
        public string NetworkProvider { get; set; }
        public bool IsDeletd { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}