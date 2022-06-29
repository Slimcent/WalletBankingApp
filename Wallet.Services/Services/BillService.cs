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
    public class BillService : IBillService
    {
        IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;
        private readonly IRepository<Bill> _billRepo;
        private readonly IUnitOfWork _unitOfWork;

        public BillService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _billRepo = _unitOfWork.GetRepository<Bill>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }

        public async Task<Response> AddBill(CreateBillDto model)
        {
            var existingBill = await _billRepo.GetSingleByAsync(b => b.BillName == model.BillName.Trim().ToLower());
            if (existingBill != null)
                return new Response(false, "Bill Name already Exist");

            var billDto = _mapper.Map<Bill>(model);

            await _billRepo.AddAsync(billDto);

            return new Response(true, $"Bill Name {model.BillName} and Amount {model.Amount} has been created Successfully!");
        }

        public async Task<Response> EditBill(Guid Id, JsonPatchDocument<PatchBillDto> model)
        {
            var bill = await _billRepo.GetByIdAsync(Id);

            if (bill is null)
                return new Response(false, "Bill does not Exist");

            var billDto = new PatchBillDto
            {
                BillName = bill.BillName,
                Amount = bill.Amount
            };

            model.ApplyTo(billDto);

            _mapper.Map(billDto, bill);

            _billRepo.Update(bill);

            return new Response(true, $"Bill Updated Successfully, see Details below\nBill Name : {bill.BillName} \nAmount : {bill.Amount}");
        }

        public async Task<Response> DeleteBillByName(string name)
        {
            var bill = await _billRepo.GetSingleByAsync(b => b.BillName == name.Trim().ToLower());

            if (bill is null)
                return new Response(false, "Bill does not Exist");

            _billRepo.Delete(bill);

            return new Response(true, $"Bill with Name {bill.BillName} And Amount {bill.Amount} has been deleted Successfully");
        }

        public async Task<IEnumerable<BillsResponseDto>> GetAllBills()
        {
            var allBills = await _billRepo.GetAllAsync();

            var billsDto = _mapper.Map<IEnumerable<BillsResponseDto>>(allBills);

            return billsDto;
        }

        public IEnumerable<Bill> GetTotalNumberOfBills()
        {
            return _billRepo.GetAll();
        }
    }
}
