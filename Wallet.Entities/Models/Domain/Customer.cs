using System;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Customer : ITracker
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string PhoneNumber { get; set; }

        public Guid AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
