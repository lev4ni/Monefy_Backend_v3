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

            CreateMap<EntityExpense, ExpenseDTO>()
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
               .ForMember(dest => dest.WalletId, opt => opt.MapFrom(src => src.Wallet.Id));

            CreateMap<Expense, EntityExpense>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Wallet, opt => opt.MapFrom(src => src.Wallet));

            CreateMap<IncomeDTO, EntityIncome>()
                .ForMember(dest => dest.Wallet, opt => opt.MapFrom(src => new EntityWallet { Id = src.WalletId }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new EntityCategory { Id = src.CategoryId }));

            CreateMap<EntityIncome, IncomeDTO>()
                .ForMember(dest => dest.WalletId, opt => opt.MapFrom(src => src.Wallet.Id))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id));

            CreateMap<UserDTO, EntityUser>();
            CreateMap<EntityUser, UserDTO>();

            CreateMap<WalletDTO, EntityWallet>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new EntityUser { Id = src.UserId }));
            CreateMap<EntityWallet, WalletDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));
        }
    }
}
