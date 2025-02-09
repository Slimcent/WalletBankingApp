﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.GobalMessage;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class DataService : IDataService
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;
        private readonly IRepository<Entities.Models.Domain.NetworkData> _dataRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DataService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _dataRepo = _unitOfWork.GetRepository<Entities.Models.Domain.NetworkData>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }

        public async Task<Response> AddData(CreateNetworkProviderDto model)
        {
            var existingData = await _dataRepo.GetSingleByAsync(predicate: d => d.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if (existingData != null)
                return new Response(false, "Network Provider name already Exist");

            var dataDto = _mapper.Map<Entities.Models.Domain.NetworkData>(model);

            await _dataRepo.AddAsync(dataDto);

            return new Response(true, $"Network Provider Name {model.NetworkProvider} has been added Successfully!");
        }

        public async Task<Response> EditData(Guid Id, JsonPatchDocument<PatchNetworkProviderDto> model)
        {
            var data = await _dataRepo.GetByIdAsync(Id);

            if (data is null)
                return new Response(false, "Data does not Exist");

            var dataDto = new PatchNetworkProviderDto
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
                
        public IEnumerable<Entities.Models.Domain.NetworkData> GetTotalNumberOfData()
        {
            return _dataRepo.GetAll();
        }
    }
}
