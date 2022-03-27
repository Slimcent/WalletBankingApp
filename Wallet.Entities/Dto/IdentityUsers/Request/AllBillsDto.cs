using System;

namespace Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto
{
    public class AllBillsDto
    {
        public string BillName { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
