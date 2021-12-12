using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;
using Wallet.Repository.Interfaces;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly IRepository<Transaction> _transactionRepo;
        private readonly IRepository<Account> _accountRepo;
        private readonly IRepository<BillPayment> _billRepo;
        private readonly IRepository<AirTime> _airTimeRepo;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory, IMapper mapper)
        {
            _accountRepo = unitOfWork.GetRepository<Account>();
            _transactionRepo = unitOfWork.GetRepository<Transaction>();
            _billRepo = unitOfWork.GetRepository<BillPayment>();
            _airTimeRepo = unitOfWork.GetRepository<AirTime>();
            _mapper = mapper;
            _serviceFactory = serviceFactory;
        }

        public async Task<Response> Deposit(DepositDto model)
        {
            //IAccountService _accountService = _serviceFactory.GetServices<AccountService>();
            //var account = _accountService.GetAccountNumber(model.WalletID);
            var wallet = _accountRepo.GetSingleByCondition(a => a.WalletID == model.WalletID);
            if (wallet == null)
                return new Response(false, "Please, indicate your Wallet Account");

            if (!wallet.IsActive) return new Response(false, "Your Wallet Account is not Active for now");

            if (model.Amount <= 0) return new Response(false, "You cannot Deposit below 0 Amount");

            wallet.Balance += model.Amount;

            //var depositDto = _mapper.Map<Transaction>(model);

            var deposit = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Credit,
                ReceiverWalletId = wallet.WalletID,
                TransactionMode = TransactionMode.Deposit,
                UserId = wallet.UserId
            };
            await  _transactionRepo.AddAsync(deposit);

            return new Response(true, $"Your Deposit of {model.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");
        }


        public async Task<Response> Withdraw(WithdrawalDto model)
        {
            var wallet = _accountRepo.GetSingleByCondition(a => a.WalletID == model.WalletID);
            if (wallet == null)
                return new Response(false, "Please, indicate your Wallet Account");

            if (!wallet.IsActive) return new Response(false, "Your Account is not Active for now");

            if (model.Amount < 50) return new Response(false, "You cannot Withdraw below 50");

            if (model.Amount > 150000) return new Response(false, "You cannot Withdraw above your daily limit of 150,000");

            if (model.Amount >= (wallet.Balance - 1000)) return new Response(false, "You cannot Withdraw above your  Wallet Balance");

            wallet.Balance -= model.Amount;

            var withdraw = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                ReceiverWalletId = wallet.WalletID,
                TransactionMode = TransactionMode.Withdraw,
                UserId = wallet.UserId
            };
            await _transactionRepo.AddAsync(withdraw);

            return new Response(true, $"Your Withdrawal of {model.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");
        }

        public async Task<Response> Transfer(TransferDto model)
        {
            var senderWallet = _accountRepo.GetSingleByCondition(a => a.WalletID == model.SenderWalletID);
            if (senderWallet == null)
                return new Response(false, "Please, Indicate Sending Wallet");

            var receiverWallet = _accountRepo.GetSingleByCondition(a => a.WalletID == model.ReceiverWalletID);
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

            var transferSender = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                SenderWalletId = senderWallet.WalletID,
                TransactionMode = TransactionMode.Transfer,
                UserId = senderWallet.UserId
            };

            var transferReceiver = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Credit,
                ReceiverWalletId = receiverWallet.WalletID,
                TransactionMode = TransactionMode.Transfer,
                UserId = receiverWallet.UserId
            };
            await _transactionRepo.AddAsync(transferReceiver);

            return new Response(true, $"Your Transfer of {model.Amount} was Successful! \nYour new Wallet Ballance is {senderWallet.Balance}" );
        }

        public async Task<Response> PayBill(PayBillDto model)
        {
            var wallet = _accountRepo.GetSingleByCondition(a => a.WalletID == model.WalletId);
            if (wallet == null)
                return new Response(false, "Please, indicate your Wallet Account");

            var bill = _billRepo.GetSingleByCondition(a => a.BillName == model.Bill.Trim().ToLower());
            if (bill == null)
                return new Response(false, "Please, indicate The Bill you want to pay for");

            if (!wallet.IsActive) return new Response(false, "Your Account is not Active for now");

            if (wallet.Balance < bill.Amount) return new Response(false, "Your Wallet Balance is Insufficient for this Bill");

            if (wallet.Balance <= (wallet.Balance - 1000)) return new Response(false, "Your Wallet Balance is Insufficient");

            wallet.Balance -= bill.Amount;
            wallet.Balance -= 100;

            var billPayment = new Transaction()
            {
                Amount = bill.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                SenderWalletId = wallet.WalletID,
                TransactionMode = TransactionMode.Bill,
                BillName = bill.BillName,
                StampDuty = 100,
                UserId = wallet.UserId
            };
            await _transactionRepo.AddAsync(billPayment);

            return new Response(true, $"Your {bill.BillName} payment of {bill.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");

        }

        public async Task<Response> BuyAirTime(BuyAirTimeDto model)
        {
            var wallet = _accountRepo.GetSingleByCondition(a => a.WalletID == model.WalletId);
            if (wallet == null)
                return new Response(false, "Please, indicate your Wallet Account");

            var airTime = _airTimeRepo.GetSingleByCondition(a => a.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if (airTime == null)
                return new Response(false, "Please, indicate the Network Provider");

            if (!wallet.IsActive) return new Response(false, "Your Account is not Active for now");

            if (model.Amount < 50) return new Response(false, "You cannot buy AirTme below 50");

            if (wallet.Balance < model.Amount) return new Response(false, "Your Wallet Balance is Insufficient for this AirTime Purchase");

            if (wallet.Balance <= (wallet.Balance - 1000)) return new Response(false, "Your Wallet Balance is Insufficient");

            wallet.Balance -= model.Amount;

            wallet.Balance -= model.Amount;

            var airTimePurchase = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                SenderWalletId = wallet.WalletID,
                PhoneNumber = model.PhoneNumber,
                NetworkProvider = airTime.NetworkProvider,
                TransactionMode = TransactionMode.AirTime,
                UserId = wallet.UserId
            };
            await _transactionRepo.AddAsync(airTimePurchase);

            return new Response(true, $"Your AirTime Purchase of {airTime.NetworkProvider} {model.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");
        }

        public async Task<Response> BuyData(BuyDataDto model)
        {
            var wallet = _accountRepo.GetSingleByCondition(a => a.WalletID == model.WalletId);
            if (wallet == null)
                return new Response(false, "Please, indicate your Wallet Account");

            var data = _airTimeRepo.GetSingleByCondition(a => a.NetworkProvider == model.NetworkProvider.Trim().ToLower());
            if (data == null)
                return new Response(false, "Please, indicate the Network Provider");

            if (!wallet.IsActive) return new Response(false, "Your Account is not Active for now");

            if (model.Amount < 50) return new Response(false, "You cannot buy Data below 50");

            if (wallet.Balance < model.Amount) return new Response(false, "Your Wallet Balance is Insufficient for this Data Purchase");

            if (wallet.Balance <= (wallet.Balance - 1000)) return new Response(false, "Your Wallet Balance is Insufficient");

            wallet.Balance -= model.Amount;

            wallet.Balance -= model.Amount;

            var dataPurchase = new Transaction()
            {
                Amount = model.Amount,
                TimeStamp = DateTime.Now,
                TransactionType = TransactionType.Debit,
                SenderWalletId = wallet.WalletID,
                PhoneNumber = model.PhoneNumber,
                NetworkProvider = data.NetworkProvider,
                TransactionMode = TransactionMode.Data,
                UserId = wallet.UserId
            };
            await _transactionRepo.AddAsync(dataPurchase);

            return new Response(true, $"Your Data Purchase of {data.NetworkProvider} {model.Amount} was Successful! \nYour new Wallet Ballance is {wallet.Balance}");
        }

        public IEnumerable<Transaction> GetTramsctionByAUser(string id)
        {
            return _transactionRepo.GetByCondition(t => t.UserId == id);
        }
    }
}
