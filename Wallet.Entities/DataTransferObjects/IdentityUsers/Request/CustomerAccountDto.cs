namespace Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto
{
    public class CustomerAccountDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WalletID { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }
}
