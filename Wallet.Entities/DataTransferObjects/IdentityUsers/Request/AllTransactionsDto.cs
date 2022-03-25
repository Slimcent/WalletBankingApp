namespace Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto
{
    public class AllTransactionsDto
    {
        public string UserId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionMode { get; set; }
        public decimal Amount { get; set; }
        public string SenderWalletId { get; set; }
        public string ReceiverWalledId { get; set; }
        public string BillName { get; set; }
        public string NetworkProvider { get; set; }
        public string PhoneNumber { get; set; }
        public decimal StampDuty { get; set; }
        public System.DateTime TimeStamp { get; set; }
    }
}
