using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.DataTransferObjects.Transaction
{
    public class AddDataNetworkProviderDto
    {
        [Display(Name = "Network Name"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name Format")]
        public string NetworkName { get; set; }
    }
}
