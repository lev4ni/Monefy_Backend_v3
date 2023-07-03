using AutoMapper;
using Monefy.Application.DTOs;
using Monefy.Entities;

namespace Monefy.Application.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<CurrencyDTO, Currency>();
            CreateMap<Currency, CurrencyDTO>();

            CreateMap<ExpenseDTO, Expense>();
            CreateMap<Expense, ExpenseDTO>();

            CreateMap<IncomeDTO, Income>();
            CreateMap<Income, IncomeDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<WalletDTO, Wallet>();
            CreateMap<Wallet, WalletDTO>();
        }
    }
}
