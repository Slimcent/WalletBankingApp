using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.Dto.IdentityUsers.Patch;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.PostDto;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Dto.Transaction.PostDto;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;
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

        public async Task<IEnumerable<NetworkProviderResponseDto>> GetAllAirTime()
        {
            IEnumerable<AirTime> allAirTime = await _airTimeRepo.GetAllAsync();

            IEnumerable<NetworkProviderResponseDto> airTimeDto = _mapper.Map<IEnumerable<NetworkProviderResponseDto>>(allAirTime);

            return airTimeDto;
        }

        public IEnumerable<AirTime> GetTotalNumberOfAirTime()
        {
            return _airTimeRepo.GetAll();
        }

        public async Task<Response> AddAirTime(CreateNetworkProviderDto model)
        {
            var existingAirTime = await _airTimeRepo.GetSingleByAsync(a => a.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if (existingAirTime != null)
                return new Response(false, "Network Provider name already Exist");

            var airTimeDdto = _mapper.Map<AirTime>(model);

            await _airTimeRepo.AddAsync(airTimeDdto);

            return new Response(true, $" AiiTime {model.NetworkProvider} has been created Successfully!");
        }

        public async Task<Response> EditAirTime(Guid Id, JsonPatchDocument<PatchNetworkProviderDto> model)
        {
            var airTime = await _airTimeRepo.GetByIdAsync(Id);

            if (airTime is null)
                return new Response(false, "ArTime does not Exist");

            var airTimeDto = new PatchNetworkProviderDto
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

        public async Task<Response> DeleteAirTimeById(Guid airTimeId)
        {
            AirTime airTime = await _airTimeRepo.GetSingleByAsync(a => a.Id == airTimeId);

            if (airTime is null)
                return new Response(false, $"AirTime with Id {airTimeId} does not Exist");

            _airTimeRepo.Delete(airTime);

            return new Response(true, $"AirTime with Name {airTime.NetworkProvider} has been deleted Successfully");
        }

        public async Task<Response> ToggleAirTimeStatus(Guid airTimeId)
        {
            AirTime airTime = await _airTimeRepo.GetSingleByAsync(a => a.Id == airTimeId);

            if (airTime is null)
                return new Response(false, $"AirTime with Id {airTimeId} does not Exist");

           airTime.IsDeletd = !airTime.IsDeletd;

           await _airTimeRepo.UpdateAsync(airTime);

            if(airTime.IsDeletd == true)
            {
                return new Response(true, $"AirTime with Name {airTime.NetworkProvider} has been deleted Successfully");
            }
            else
            {
                return new Response(true, $"AirTime with Name {airTime.NetworkProvider} has been activated Successfully");
            }
        }
    }
}
