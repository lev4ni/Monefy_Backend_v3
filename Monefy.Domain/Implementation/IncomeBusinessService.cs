using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;
using Monefy.Infraestructure.Repository.Implementations;

namespace Monefy.Domain.Implementation
{
	public class IncomeBusinessService : IIncomeBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIncomeRepository _incomeRepository;
		public IncomeBusinessService(IUnitOfWork unitOfWork, IIncomeRepository incomeRepository)
		{
			_unitOfWork = unitOfWork;
			_incomeRepository = incomeRepository;
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
			await _incomeRepository.AddAsync(income);
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
        public async Task<IEnumerable<EntityIncome>> GetWalletIncomesAsync(int walletId)
        {
            return await _incomeRepository.GetWalletIncomesAsync(walletId);
        }
    }
}