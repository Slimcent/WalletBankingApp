using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;

namespace Wallet.Services
{
    public class DataService : IDataService
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;
        private readonly IRepository<Entities.Models.Domain.Data> _dataRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DataService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _dataRepo = _unitOfWork.GetRepository<Entities.Models.Domain.Data>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }

        public async Task<Response> AddData(AddNetworkProviderDto model)
        {
            var existingData = await _dataRepo.GetSingleByAsync(predicate: d => d.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if (existingData != null)
                return new Response(false, "Network Provider name already Exist");

            var dataDto = _mapper.Map<Entities.Models.Domain.Data>(model);

            await _dataRepo.AddAsync(dataDto);

            return new Response(true, $"Network Provider Name {model.NetworkProvider} has been added Successfully!");
        }

        public async Task<Response> EditData(Guid Id, JsonPatchDocument<PatchDataDto> model)
        {
            var data = await _dataRepo.GetByIdAsync(Id);

            if (data is null)
                return new Response(false, "Data does not Exist");

            var dataDto = new PatchDataDto
            {
                NetworkProvider = data.NetworkProvider
            };

            model.ApplyTo(dataDto);

            _mapper.Map(dataDto, data);

            _dataRepo.Update(data);

            return new Response(true, $"Data Updated Successfully, see Details below \nNetwork Name : {data.NetworkProvider}");
        }

        public async Task<Response> DeleteDataByName(string name)
        {
            var data = await _dataRepo.GetSingleByAsync(d => d.NetworkProvider == name.Trim().ToLower());

            if (data is null)
                return new Response(false, "Data does not Exist");

            _dataRepo.Delete(data);

            return new Response(true, $"Data with Name {data.NetworkProvider} has been deleted Successfully");
        }

        public async Task<IEnumerable<AllDataDto>> GetAllData()
        {
            var allData = await _dataRepo.GetAllAsync();

            var dataDto = _mapper.Map<IEnumerable<AllDataDto>>(allData);

            return dataDto;
        }

        public IEnumerable<Entities.Models.Domain.Data> GetTotalNumberOfData()
        {
            return _dataRepo.GetAll();
        }
    }
}
