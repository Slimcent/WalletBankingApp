using System;

namespace Wallet.Entities.Dto.Response
{
    public class BillsResponseDto
    {
        public Guid Id { get; set; }
        public string BillName { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
