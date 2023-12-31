﻿using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.Repository.Implementations;

namespace Monefy.Domain.Implementation
{
    public class IncomeBusinessService : IIncomeBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIncomeRepository _incomeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWalletRepository _walletRepository;
        public IncomeBusinessService(IUnitOfWork unitOfWork, IIncomeRepository incomeRepository, ICategoryRepository categoryRepository, IWalletRepository walletRepository)
        {
            _unitOfWork = unitOfWork;
            _incomeRepository = incomeRepository;
            _categoryRepository = categoryRepository;
            _walletRepository = walletRepository;
        }
        public async Task<IEnumerable<EntityIncome>> GetAllIncomesAsync()
        {
            var income = await _incomeRepository.GetAllAsync();
            return income;
        }

        public async Task<EntityIncome> GetIncomeByIdAsync(int id)
        {
            var income = await _incomeRepository.GetByIdAsync(id);
            return income;
        }
        public async Task CreateIncomeAsync(EntityIncome income)
        {
            var category = await _categoryRepository.GetByIdAsync(income.Category.Id);
            var wallet = await _walletRepository.GetByIdAsync(income.Wallet.Id);

            if (category == null)
            {
                throw new ArgumentException("Invalid category");
            }

            if (wallet == null)
            {
                throw new ArgumentException("Invalid wallet");
            }

            income.Category = category;
            income.Wallet = wallet;
            await _incomeRepository.AddAsync(income);

            wallet.TotalIncome += income.Amount;
            wallet.TotalBalance += income.Amount;
            await _walletRepository.UpdateAsync(wallet);

            var totalWallet = await _walletRepository.getWalletByUserAndName(wallet.User.Id, "all");
            totalWallet.TotalIncome += income.Amount;
            totalWallet.TotalBalance += income.Amount;
            await _walletRepository.UpdateAsync(totalWallet);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateIncomeAsync(EntityIncome income)
        {
            await _incomeRepository.UpdateAsync(income);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteIncomeAsync(int id)
        {
            await _incomeRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<EntityIncome>> GetWalletIncomesAsync(int walletId, DateTime initialDate, DateTime finalDate)
        {
            return await _incomeRepository.GetWalletIncomesAsync(walletId, initialDate, finalDate);
        }
    }
}