using AutoMapper;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Domain.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<EntityCategory, Category>();
            CreateMap<Category, EntityCategory>();

            CreateMap<EntityCurrency, Currency>();
            CreateMap<Currency, EntityCurrency>();

            CreateMap<EntityExpense, Expense>();
            CreateMap<Expense, EntityExpense>();

            CreateMap<EntityIncome, Income>();
            CreateMap<Income, EntityIncome>();

            CreateMap<EntityUser, User>();
            CreateMap<User, EntityUser>();

            CreateMap<EntityWallet, Wallet>();
            CreateMap<Wallet, EntityWallet>();
        }
    }
}
