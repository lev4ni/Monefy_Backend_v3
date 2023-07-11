﻿using AutoMapper;
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

            CreateMap<ExpenseDTO, EntityExpense>()
                .ForMember(dest => dest.Wallet, opt => opt.MapFrom(src => new EntityWallet { Id = src.WalletId }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new EntityCategory { Id = src.Category.Id }));
            CreateMap<EntityExpense, ExpenseDTO>();

            CreateMap<IncomeDTO, EntityIncome>()
                .ForMember(dest => dest.Wallet, opt => opt.MapFrom(src => new EntityWallet { Id = src.WalletId }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new EntityCategory { Id = src.Category.Id }));
            CreateMap<EntityIncome, IncomeDTO>();

            CreateMap<UserDTO, EntityUser>();
            CreateMap<EntityUser, UserDTO>();

            CreateMap<WalletDTO, EntityWallet>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new EntityUser { Id = src.UserId }));
            CreateMap<EntityWallet, WalletDTO>();
        }
    }
}
