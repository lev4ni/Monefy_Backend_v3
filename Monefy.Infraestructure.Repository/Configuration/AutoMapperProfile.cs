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

            CreateMap<Expense, EntityExpense>();
            CreateMap<EntityExpense, Expense>();

            CreateMap<Income, EntityIncome>();
            CreateMap<EntityIncome, Income>();

            CreateMap<User, EntityUser>();
            CreateMap<EntityUser, User>();

            CreateMap<Wallet, EntityWallet>()
                .ForPath(dest => dest.User.Id, opt => opt.MapFrom(src => src.UserId));
            CreateMap<EntityWallet, Wallet>();
        }
    }
}
