using AutoMapper;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Domain.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Category, CategoryDataModel>();
            CreateMap<CategoryDataModel, Category>();

            CreateMap<Currency, CurrencyDataModel>();
            CreateMap<CurrencyDataModel, Currency>();

            CreateMap<Expense, ExpenseDataModel>();
            CreateMap<ExpenseDataModel, Expense>();

            CreateMap<Income, IncomeDataModel>();
            CreateMap<IncomeDataModel, Income>();

            CreateMap<User, UserDataModel>();
            CreateMap<UserDataModel, User>();

            CreateMap<Wallet, WalletDataModel>();
            CreateMap<WalletDataModel, Wallet>();
        }
    }
}
