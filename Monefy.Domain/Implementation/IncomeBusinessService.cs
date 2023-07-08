using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class IncomeBusinessService : IIncomeBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIncomeInfraestrucutureService _incomeInfraestrucuture;
		public IncomeBusinessService(IUnitOfWork unitOfWork, IIncomeInfraestrucutureService incomeInfraestrucuture)
		{
			_unitOfWork = unitOfWork;
			_incomeInfraestrucuture = incomeInfraestrucuture;
		}
		public async Task<IEnumerable<EntityIncome>> GetAllIncomesAsync()
		{
			var income = await _incomeInfraestrucuture.GetAllAsync();
			return income;
		}

		public async Task<EntityIncome> GetIncomeByIdAsync(int id)
		{
			var income = await _incomeInfraestrucuture.GetByIdAsync(id);
			return income;
		}
		public async Task CreateIncomeAsync(EntityIncome income)
		{
			await _incomeInfraestrucuture.AddAsync(income);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task UpdateIncomeAsync(EntityIncome income)
		{
			await _incomeInfraestrucuture.UpdateAsync(income);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteIncomeAsync(int id)
		{
			await _incomeInfraestrucuture.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
