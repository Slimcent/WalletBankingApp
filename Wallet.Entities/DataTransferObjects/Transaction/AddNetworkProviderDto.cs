using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.Transaction
{
    public class AddNetworkProviderDto
    {
        [Display(Name = "Network Name"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name Format")]
        public string NetworkName { get; set; }
    }
}
