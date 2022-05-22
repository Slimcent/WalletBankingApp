using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.Dto.Transaction.PostDto;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepo;
        private readonly IRepository<Entities.Models.Domain.Wallet> _walletRepo;
        private readonly IRepository<Bill> _billRepo;
        private readonly IRepository<AirTime> _airTimeRepo;
        private readonly IServiceFactory _serviceFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetServices<IUnitOfWork>();
            _walletRepo = _unitOfWork.GetRepository<Entities.Models.Domain.Wallet>();
            _transactionRepo = _unitOfWork.GetRepository<Transaction>();
            _billRepo = _unitOfWork.GetRepository<Bill>();
            _airTimeRepo = _unitOfWork.GetRepository<AirTime>();
            _mapper = serviceFactory.GetServices<IMapper>();
        }

        public async Task<Response> Deposit(DepositDto model)
        {
            //IAccountService _accountService = _serviceFactory.GetServices<AccountService>();
            //var account = _accountService.GetAccountNumber(model.WalletID);
            if (model == null)
                return new Response(false, "Please, indicate your Wallet No");

            var wallet = await _walletRepo.GetSingleByAsync(a => a.WalletNo == model.WalletID);
            if (wallet == null)
                return new Response(false, "Wallet No does not exist, check and try again");

            if (!wallet.IsActive) return new Response(false, "Your Wallet Account is not Active for now");

            if (model.Amount <= 0) return new Response(false, "You cannot Deposit 0 Amount");

            wallet.Balance += model.Amount;
            await _walletRepo.UpdateAsync(wallet);

            var deposit = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Credit,
                ReceiverWalletId = wallet.WalletNo,
                TransactionMode = TransactionMode.Deposit,
                CustomerId = wallet.CustomerId
            };
            await  _transactionRepo.AddAsync(deposit);
            await _unitOfWork.SaveChangesAsync();

            return new Response(true, $"Your Deposit of {model.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");
        }


        public async Task<Response> Withdraw(WithdrawalDto model)
        {
            if (model == null)
                return new Response(false, "Please, indicate your Wallet No");

            var wallet = await _walletRepo.GetSingleByAsync(a => a.WalletNo == model.WalletID);
            if (wallet == null)
                return new Response(false, "Please, indicate your Wallet Account");

            if (!wallet.IsActive) return new Response(false, "Your Account is not Active for now, contact the bank");

            if (model.Amount < 50) return new Response(false, "You cannot Withdraw below 50");

            if (model.Amount > 150000) return new Response(false, "You cannot Withdraw above your daily limit of 150,000");

            if (model.Amount >= (wallet.Balance - 1000)) return new Response(false, "You cannot Withdraw above your  Wallet Balance");

            wallet.Balance -= model.Amount;
            await _walletRepo.UpdateAsync(wallet);

            var withdraw = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                ReceiverWalletId = wallet.WalletNo,
                TransactionMode = TransactionMode.Withdraw,
                CustomerId = wallet.CustomerId
            };
            await _transactionRepo.AddAsync(withdraw);
            await _unitOfWork.SaveChangesAsync();

            return new Response(true, $"Your Withdrawal of {model.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");
        }

        public async Task<Response> Transfer(TransferDto model)
        {
            if (model == null)
                return new Response(false, "Please, indicate your Wallet No");

            var senderWallet =  await _walletRepo.GetSingleByAsync(a => a.WalletNo == model.SenderWalletID);
            if (senderWallet == null)
                return new Response(false, "Please, Indicate Sending Wallet");

            var receiverWallet = await _walletRepo.GetSingleByAsync(a => a.WalletNo == model.ReceiverWalletID);
            if (receiverWallet == null)
                return new Response(false, "Please, Indicate Recipient Wallet");

            if (!senderWallet.IsActive) return new Response(false, "Your Account is not Active for now");

            if (!receiverWallet.IsActive) return new Response(false, "Recipient Wallet is not Active for now");

            if (receiverWallet == senderWallet) return new Response(false, "You cannot Transfer to your Wallet Account");

            if (model.Amount <= 0) return new Response(false, "You cannot Transfer 0 Amount");

            if (model.Amount > 1000000) return new Response(false, "You cannot Transfer above your daily limit of 1,000,000");

            if (model.Amount >= (senderWallet.Balance - 1000)) return new Response(false, "You cannot Transfer above your Wallet Balance");

            senderWallet.Balance -= model.Amount;
            receiverWallet.Balance += model.Amount;
            await _walletRepo.UpdateAsync(senderWallet);
            await _walletRepo.UpdateAsync(receiverWallet);

            var transferSender = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                SenderWalletId = senderWallet.WalletNo,
                TransactionMode = TransactionMode.Transfer,
                CustomerId = senderWallet.CustomerId
            };

            var transferReceiver = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Credit,
                ReceiverWalletId = receiverWallet.WalletNo,
                TransactionMode = TransactionMode.Transfer,
                CustomerId = receiverWallet.CustomerId
            };
            await _transactionRepo.AddAsync(transferReceiver);
            await _unitOfWork.SaveChangesAsync();

            return new Response(true, $"Your Transfer of {model.Amount} to {receiverWallet.WalletNo} was Successful! \nYour new Wallet Ballance is {senderWallet.Balance}" );
        }

        public async Task<Response> PayBill(PayBillDto model)
        {
            if (model == null)
                return new Response(false, "Please, indicate your Wallet No");

            var wallet = await _walletRepo.GetSingleByAsync(a => a.WalletNo == model.WalletId);
            if (wallet == null)
                return new Response(false, "Please, indicate your Wallet Account");

            var bill = await _billRepo.GetSingleByAsync(a => a.BillName == model.Bill.Trim().ToLower());
            if (bill == null)
                return new Response(false, "Please, indicate The Bill you want to pay for");

            if (!wallet.IsActive) return new Response(false, "Your Account is not Active for now");

            if (wallet.Balance < bill.Amount) return new Response(false, "Your Wallet Balance is Insufficient for this Bill");

            if (wallet.Balance <= (wallet.Balance - 1000)) return new Response(false, "Your Wallet Balance is Insufficient");

            wallet.Balance -= bill.Amount;
            wallet.Balance -= 100;
            await _walletRepo.UpdateAsync(wallet);

            var billPayment = new Transaction()
            {
                Amount = bill.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                SenderWalletId = wallet.WalletNo,
                TransactionMode = TransactionMode.Bill,
                BillName = bill.BillName,
                StampDuty = 100,
                CustomerId = wallet.CustomerId
            };
            await _transactionRepo.AddAsync(billPayment);
            await _unitOfWork.SaveChangesAsync();

            return new Response(true, $"Your {bill.BillName} payment of {bill.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");

        }

        public async Task<Response> BuyAirTime(BuyAirTimeDto model)
        {
            if (model == null)
                return new Response(false, "Please, indicate your Wallet No");

            var wallet = await _walletRepo.GetSingleByAsync(a => a.WalletNo == model.WalletId);
            if (wallet == null)
                return new Response(false, "Please, indicate your Wallet Account");

            var airTime = await _airTimeRepo.GetSingleByAsync(a => a.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if (airTime == null)
                return new Response(false, "Please, indicate the Network Provider");

            if (!wallet.IsActive) return new Response(false, "Your Account is not Active for now");

            if (model.Amount < 50) return new Response(false, "You cannot buy AirTme below 50");

            if (wallet.Balance < model.Amount) return new Response(false, "Your Wallet Balance is Insufficient for this AirTime Purchase");

            if (wallet.Balance <= (wallet.Balance - 1000)) return new Response(false, "Your Wallet Balance is Insufficient");

            wallet.Balance -= model.Amount;
            await _walletRepo.UpdateAsync(wallet);           

            var airTimePurchase = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                SenderWalletId = wallet.WalletNo,
                PhoneNumber = model.PhoneNumber,
                NetworkProvider = airTime.NetworkProvider,
                TransactionMode = TransactionMode.AirTime,
                CustomerId = wallet.CustomerId
            };
            await _transactionRepo.AddAsync(airTimePurchase);
            await _unitOfWork.SaveChangesAsync();

            return new Response(true, $"Your AirTime Purchase of {airTime.NetworkProvider} {model.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");
        }

        public async Task<Response> BuyData(BuyDataDto model)
        {
            if (model == null)
                return new Response(false, "Please, indicate your Wallet No");

            var wallet = await _walletRepo.GetSingleByAsync(a => a.WalletNo == model.WalletId);
            if (wallet == null)
                return new Response(false, "Please, indicate your Wallet Account");

            var data = await _airTimeRepo.GetSingleByAsync(a => a.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if (data == null)
                return new Response(false, "Please, indicate the Network Provider");

            if (!wallet.IsActive) return new Response(false, "Your Account is not Active for now");

            if (model.Amount < 50) return new Response(false, "You cannot buy Data below 50");

            if (wallet.Balance < model.Amount) return new Response(false, "Your Wallet Balance is Insufficient for this Data Purchase");

            if (wallet.Balance <= (wallet.Balance - 1000)) return new Response(false, "Your Wallet Balance is Insufficient");

            wallet.Balance -= model.Amount;
            await _walletRepo.UpdateAsync(wallet);

            var dataPurchase = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                SenderWalletId = wallet.WalletNo,
                PhoneNumber = model.PhoneNumber,
                NetworkProvider = data.NetworkProvider,
                TransactionMode = TransactionMode.Data,
                CustomerId = wallet.CustomerId
            };
            await _transactionRepo.AddAsync(dataPurchase);
            await _unitOfWork.SaveChangesAsync();

            return new Response(true, $"Your Data Purchase of {data.NetworkProvider} {model.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");
        }

        public IEnumerable<Transaction> GetTramsctionByAUser(string id)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Transaction> GetTramsctionByAUser(string id)
        //{
        //    return _transactionRepo.GetByCondition(t => t.UserId == id);
        //}
    }
}
