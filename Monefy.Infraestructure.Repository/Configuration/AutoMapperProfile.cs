using AutoMapper;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Infraestructure.Repository.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CategoryDataModel, Category>();
            CreateMap<Category, CategoryDataModel>();

            CreateMap<CurrencyDataModel, Currency>();
            CreateMap<Currency, CurrencyDataModel>();

            CreateMap<ExpenseDataModel, Expense>();
            CreateMap<Expense, ExpenseDataModel>();

            CreateMap<IncomeDataModel, Income>();
            CreateMap<Income, IncomeDataModel>();

            CreateMap<UserDataModel, User>();
            CreateMap<User, UserDataModel>();

            CreateMap<WalletDataModel, Wallet>();
            CreateMap<Wallet, WalletDataModel>();
        }
    }
}
