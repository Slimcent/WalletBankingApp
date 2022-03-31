using System;
using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Models.Domain
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public int PlotNo { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Nationality { get; set; }
        public Guid CustomerId { get; set; }
        public Guid StaffId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
