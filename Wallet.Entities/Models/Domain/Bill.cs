using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Bill : ITracker
    {
        [Column(TypeName = "varchar(256)")]
        public string Id { get; set; }

        [Unicode(false)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<BillMode> BillMode { get; set; }
    }
}