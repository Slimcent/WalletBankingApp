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

        public async Task<IEnumerable<BillsResponseDto>> GetAllBills()
        {
            IEnumerable<Bill> allBills = await _unitOfWork.GetRepository<Bill>().GetAllAsync();

            IEnumerable<BillsResponseDto> billsResponse = _mapper.Map<IEnumerable<BillsResponseDto>>(allBills);

            return billsResponse;
        }
    }
}
