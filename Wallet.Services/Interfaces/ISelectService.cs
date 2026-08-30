using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Response;

namespace Wallet.Services.Interfaces
{
    public interface ISelectService
    {
        Task<IEnumerable<BillsResponseDto>> GetAllBills();
    }
}
