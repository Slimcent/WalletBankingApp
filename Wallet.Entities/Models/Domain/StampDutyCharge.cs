using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Entities.Models.Domain
{
    public class StampDutyCharge
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }
    }
}