using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Response;

namespace Wallet.Services.Interfaces
{
    public interface ISelectService
    {
        Task<IEnumerable<NetworkProviderResponseDto>> GetAllAirTime();

        Task<IEnumerable<BillsResponseDto>> GetAllBills();

        Task<IEnumerable<NetworkProviderResponseDto>> GetAllData();
    }
}
