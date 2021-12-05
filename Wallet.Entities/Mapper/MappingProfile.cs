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
        }
    }
}
