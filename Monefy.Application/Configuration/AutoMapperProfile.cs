using AutoMapper;
using Monefy.Application.DTOs;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Application.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CategoryDTO, EntityCategory>();
            CreateMap<EntityCategory, CategoryDTO>();

            CreateMap<CurrencyDTO, EntityCurrency>();
            CreateMap<EntityCurrency, CurrencyDTO>();

            CreateMap<ExpenseDTO, EntityExpense>()
                .ForMember(dest => dest.Wallet, opt => opt.MapFrom(src => new EntityWallet { Id = src.WalletId }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new EntityCategory { Id = src.CategoryId }));
            CreateMap<EntityExpense, ExpenseDTO>();

            CreateMap<IncomeDTO, EntityIncome>()
                .ForMember(dest => dest.Wallet, opt => opt.MapFrom(src => new EntityWallet { Id = src.WalletId }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new EntityCategory { Id = src.CategoryId }));
            CreateMap<EntityIncome, IncomeDTO>();

            CreateMap<UserDTO, EntityUser>();
            CreateMap<EntityUser, UserDTO>();

            CreateMap<UserDTO, EntityUser>();
            CreateMap<EntityUser, UserDTO>();

            CreateMap<WalletDTO, EntityWallet>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new EntityUser { Id = src.UserId }));
            CreateMap<EntityWallet, WalletDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));
        }
    }
}
