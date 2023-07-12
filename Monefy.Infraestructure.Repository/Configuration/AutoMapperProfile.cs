using AutoMapper;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Infraestructure.Repository.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Category, EntityCategory>();
            CreateMap<EntityCategory, Category>();

            CreateMap<Currency, EntityCurrency>();
            CreateMap<EntityCurrency, Currency>();

            CreateMap<Expense, EntityExpense>()
                .ForPath(dest => dest.Category.Id, opt => opt.MapFrom(src => src.CategoryId))
                .ForPath(dest => dest.Wallet.Id, opt => opt.MapFrom(src => src.WalletId));
            CreateMap<EntityExpense, Expense>();

            CreateMap<Income, EntityIncome>()
                .ForPath(dest => dest.Category.Id, opt => opt.MapFrom(src => src.CategoryId))
                .ForPath(dest => dest.Wallet.Id, opt => opt.MapFrom(src => src.WalletId));
            CreateMap<EntityIncome, Income>();

            CreateMap<User, EntityUser>();
            CreateMap<EntityUser, User>();

            CreateMap<Wallet, EntityWallet>()
                .ForPath(dest => dest.User.Id, opt => opt.MapFrom(src => src.UserId));
            CreateMap<EntityWallet, Wallet>();
        }
    }
}
