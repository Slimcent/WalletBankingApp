using AutoMapper;
using System;
using Wallet.Entities.Dto.IdentityUsers.PostDto;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.Enumerators;
using Wallet.Entities.Models.Domain;

namespace Wallet.Entities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Create User
            CreateMap<CreateUserDto, User>();

            
            CreateMap<Transaction, AllTransactionsDto>();
            CreateMap<Role, RoleResponseDto>();
            CreateMap<Bill, BillsResponseDto>();
            CreateMap<AirTime, NetworkProviderResponseDto>();
            CreateMap<Models.Domain.Data, NetworkProviderResponseDto>();
           
            CreateMap<RoleDto, Role>();
            CreateMap<CreateBillDto, Bill>();
            CreateMap<CreateNetworkProviderDto, Models.Domain.Data>();
            CreateMap<CreateNetworkProviderDto, AirTime>();
            CreateMap<DepositTransactionDto, Transaction>();
            CreateMap<PatchUserDto, User>();
            CreateMap<PatchRoleDto, Role>();
            CreateMap<PatchBillDto, Bill>();
            CreateMap<PatchNetworkProviderDto, AirTime>();
            CreateMap<PatchNetworkProviderDto, Models.Domain.Data>();

            //CreateMap<Staff, UpdateStaffDto>()
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

            // Update Staff by Patch
            CreateMap<UpdateStaffDto, Staff>()
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email));

            // Update Staff and Customer by Put
            CreateMap<UpdateAddressDto, Address> ();

            // Get all staff and Get staff by Id 
            CreateMap<Staff, StaffResponseDto> ()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => 
                $"{src.Address.PlotNo} {src.Address.StreetName} {src.Address.State} {src.Address.Nationality}"));

            // Get Staff by Email
            CreateMap<User, StaffResponseDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Staff.LastName} {src.Staff.FirstName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Staff.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => 
                $"{src.Staff.Address.PlotNo} {src.Staff.Address.StreetName} {src.Staff.Address.State} {src.Staff.Address.Nationality}"));

            // Uodate Customer by Patch
            CreateMap<UpdateStaffDto, Customer>()
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email));

            // Get all Customer and Get Customer by Id 
            CreateMap<Customer, CustomerResponseDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.WalletNo, opt => opt.MapFrom(src => src.Wallet.WalletNo))
                .ForMember(dest => dest.WalletBalance, opt => opt.MapFrom(src => src.Wallet.Balance))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => 
                $"{src.Address.PlotNo} {src.Address.StreetName} {src.Address.State} {src.Address.Nationality}"));

            // Get Customer by Email
            CreateMap<User, CustomerResponseDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Customer.LastName} {src.Customer.FirstName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.WalletNo, opt => opt.MapFrom(src => src.Customer.Wallet.WalletNo))
                .ForMember(dest => dest.WalletBalance, opt => opt.MapFrom(src => src.Customer.Wallet.Balance))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => 
                $"{src.Customer.Address.PlotNo} {src.Customer.Address.StreetName} {src.Customer.Address.State} {src.Customer.Address.Nationality}"));

            // Get Customer by Walletno
            CreateMap<Entities.Models.Domain.Wallet, CustomerResponseDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Customer.LastName} {src.Customer.FirstName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Customer.User.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.WalletNo, opt => opt.MapFrom(src => src.WalletNo))
                .ForMember(dest => dest.WalletBalance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => 
                $"{src.Customer.Address.PlotNo} {src.Customer.Address.StreetName} {src.Customer.Address.State} {src.Customer.Address.Nationality}"));

            
        }
    }
}
