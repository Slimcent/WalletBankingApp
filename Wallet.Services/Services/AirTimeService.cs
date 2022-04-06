using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;
using Wallet.Repository.Interfaces;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class AirTimeService : IAirTimeService
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;
        private readonly IRepository<AirTime> _airTimeRepo;
        private readonly IUnitOfWork _unitOfWork;

        public AirTimeService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _airTimeRepo = _unitOfWork.GetRepository<AirTime>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }

        public async Task<IEnumerable<AllAirTimeDto>> GetAllAirTime()
        {
            var allAirTime = await _airTimeRepo.GetAllAsync();

            var airTimeDto = _mapper.Map<IEnumerable<AllAirTimeDto>>(allAirTime);

            return airTimeDto;
        }

        public IEnumerable<AirTime> GetTotalNumberOfAirTime()
        {
            return _airTimeRepo.GetAll();
        }

        public async Task<Response> AddAirTime(AddNetworkProviderDto model)
        {
            var existingAirTime = await _airTimeRepo.GetSingleByAsync(a => a.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if (existingAirTime != null)
                return new Response(false, "Network Provider name already Exist");

            var airTimeDdto = _mapper.Map<AirTime>(model);

            await _airTimeRepo.AddAsync(airTimeDdto);

            return new Response(true, $" AiiTime {model.NetworkProvider} has been created Successfully!");
        }

        public async Task<Response> EditAirTime(Guid Id, JsonPatchDocument<PatchAirTimeDto> model)
        {
            var airTime = await _airTimeRepo.GetByIdAsync(Id);

            if (airTime is null)
                return new Response(false, "ArTime does not Exist");

            var airTimeDto = new PatchAirTimeDto
            {
                NetworkProvider = airTime.NetworkProvider
            };

            model.ApplyTo(airTimeDto);

            _mapper.Map(airTimeDto, airTime);

            _airTimeRepo.Update(airTime);

            return new Response(true, $"AirTime Updated Successfully, see Details below \nNetwork Name : {airTime.NetworkProvider}");
        }

        public async Task<Response> DeleteAirTimeByName(string name)
        {
            var airTime = await _airTimeRepo.GetSingleByAsync(a => a.NetworkProvider == name.Trim().ToLower());

            if (airTime is null)
                return new Response(false, "AirTime does not Exist");

            _airTimeRepo.Delete(airTime);

            return new Response(true, $"AirTime with Name {airTime.NetworkProvider} has been deleted Successfully");
        }
    }
}
