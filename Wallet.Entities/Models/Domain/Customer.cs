﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Customer : ITracker
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; }
        public Guid WalletId { get; set; }
        public Guid? AddressId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(WalletId))]
        public virtual Wallet Wallet { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }
    }
}
