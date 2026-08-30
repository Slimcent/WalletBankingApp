namespace Wallet.Data.Seeders
{
    public class Seed
    {
        public List<string> Roles { get; set; } = new();

        public List<string> Genders { get; set; } = new();

        public List<string> UserTypes { get; set; } = new();

        public List<string> TransactionTypes { get; set; } = new();

        public List<string> TransactionModes { get; set; } = new();

        public List<SeedBill> Bills { get; set; } = new();

        public List<SeedBillMode> BillModes { get; set; } = new();

        public List<SeedMenu> Menus { get; set; } = new();

        public List<SeedStampDutyCharge> StampDutyCharges { get; set; } = new();

        public SeedAdminUser AdminUser { get; set; } = new();
    }

    public class SeedAdminUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string UserType { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
    }

    public class SeedBill
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }

    public class SeedBillMode
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string BillId { get; set; } = string.Empty;
    }

    public class SeedStampDutyCharge
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }

    public class SeedMenu
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int OrderId { get; set; }
    }
}