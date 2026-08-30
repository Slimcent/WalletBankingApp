using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Entities.Models.Domain
{
    public class StampDutyCharge
    {
        [Column(TypeName = "varchar(256)")]
        public string Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(38,2)")]
        public decimal Amount { get; set; }
        public bool Active { get; set; }
    }
}