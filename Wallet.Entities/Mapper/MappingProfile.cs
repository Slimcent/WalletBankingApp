using AutoMapper;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
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
            CreateMap<BillPayment, AllBillsDto>();
            CreateMap<AirTime, AllAirTimeDto>();
            CreateMap<BuyData, AllDataDto>();
            CreateMap<Customer, CustomerAccountDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Account.IsActive))
                .ForMember(dest => dest.WalletID, opt => opt.MapFrom(src => src.Account.WalletID))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Account.Balance));
        }
    }
}
