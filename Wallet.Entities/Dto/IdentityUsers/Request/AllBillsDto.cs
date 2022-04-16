using System;

namespace Wallet.Entities.Dto.IdentityUsers.Request
{
    public class AllBillsDto
    {
        public string BillName { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
