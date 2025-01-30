using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class SelectService : ISelectService
    {
        private readonly IMapper _mapper;
        private readonly IServiceFactory _serviceFactory;
        private readonly IUnitOfWork _unitOfWork;

        public SelectService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }

        public async Task<IEnumerable<NetworkProviderResponseDto>> GetAllAirTime()
        {
            IEnumerable<AirTime> allAirTime = await _unitOfWork.GetRepository<AirTime>().GetAllAsync();

            IEnumerable<NetworkProviderResponseDto> airTimeResponse = _mapper.Map<IEnumerable<NetworkProviderResponseDto>>(allAirTime);

            return airTimeResponse;
        }

        public async Task<IEnumerable<BillsResponseDto>> GetAllBills()
        {
            IEnumerable<Bill> allBills = await _unitOfWork.GetRepository<Bill>().GetAllAsync();

            IEnumerable<BillsResponseDto> billsResponse = _mapper.Map<IEnumerable<BillsResponseDto>>(allBills);

            return billsResponse;
        }

        public async Task<IEnumerable<NetworkProviderResponseDto>> GetAllData()
        {
            IEnumerable<Entities.Models.Domain.NetworkData> allData = await _unitOfWork.GetRepository<Entities.Models.Domain.NetworkData>().GetAllAsync();

            IEnumerable<NetworkProviderResponseDto> dataResponse = _mapper.Map<IEnumerable<NetworkProviderResponseDto>>(allData);

            return dataResponse;
        }
    }
}
