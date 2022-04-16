namespace Wallet.Entities.Dto.IdentityUsers.Request
{
    public class AllUsersDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public System.DateTime CreatedAt { get; set; }
    }
}
