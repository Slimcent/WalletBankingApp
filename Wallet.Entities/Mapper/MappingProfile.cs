using AutoMapper;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.DataTransferObjects.Transaction.PostDto;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserDto, User>();

            CreateMap<User, AllUsersDto>();
            CreateMap<Transaction, AllTransactionsDto>();
            CreateMap<Role, AllRolesDto>();
            CreateMap<Bill, AllBillsDto>();
            CreateMap<AirTime, AllAirTimeDto>();
            CreateMap<Models.Domain.Data, AllDataDto>();
            //CreateMap<Customer, CustomerAccountDto>()
            //    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
            //    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            //    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
            //    .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Account.IsActive))
            //    .ForMember(dest => dest.WalletID, opt => opt.MapFrom(src => src.Account.WalletID))
            //    .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Account.Balance));
            CreateMap<AddRoleDto, Role>();
            CreateMap<AddBillDto, Bill>();
            CreateMap<AddNetworkProviderDto, Models.Domain.Data>();
            CreateMap<AddNetworkProviderDto, AirTime>();
            CreateMap<DepositTransactionDto, Transaction>();
            CreateMap<PatchUserDto, User>();
            CreateMap<PatchRoleDto, Role>();
            CreateMap<PatchBillDto, Bill>();
            CreateMap<PatchAirTimeDto, AirTime>();
            CreateMap<PatchDataDto, Models.Domain.Data>();

            //CreateMap<Staff, UpdateStaffDto>()
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<UpdateStaffDto, Staff>()
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UpdateAddressDto, Address> ();

            CreateMap<Staff, StaffResponseDto> ()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.Address.PlotNo} {src.Address.StreetName} {src.Address.State} {src.Address.Nationality}"));

            CreateMap<User, StaffResponseDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Staff.LastName} {src.Staff.FirstName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Staff.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.Staff.Address.PlotNo} {src.Staff.Address.StreetName} {src.Staff.Address.State} {src.Staff.Address.Nationality}"));

        }
    }
}
