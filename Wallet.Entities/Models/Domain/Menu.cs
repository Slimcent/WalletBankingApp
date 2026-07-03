using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Entities.Interfaces;

namespace Wallet.Entities.Models.Domain
{
    public class Menu :ITracker
    {
        [Column(TypeName = "varchar(256)")]
        public string Id { get; set; }

        [Unicode(false)]
        [MaxLength(25)]
        public string Name { get; set; }
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public IList<string>? Claims { get; set; }
    }
}
