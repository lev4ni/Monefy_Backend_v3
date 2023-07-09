using AutoMapper;
using Monefy.Application.DTOs;
using Monefy.Entities;

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

            CreateMap<ExpenseDTO, EntityExpense>();
            CreateMap<EntityExpense, ExpenseDTO>();

            CreateMap<IncomeDTO, EntityIncome>();
            CreateMap<EntityIncome, IncomeDTO>();

            CreateMap<UserDTO, EntityUser>();
            CreateMap<EntityUser, UserDTO>();

            CreateMap<WalletDTO, EntityWallet>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new EntityUser { Id = src.UserId }));
            CreateMap<EntityWallet, WalletDTO>();
        }
    }
}
