using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class CurrencyBusinessService : ICurrencyBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICurrencyInfraestrucutureService _currencyInfraestrucutureService;
		public CurrencyBusinessService(IUnitOfWork unitOfWork, ICurrencyInfraestrucutureService currencyInfraestrucutureService)
		{
			_unitOfWork = unitOfWork;
			_currencyInfraestrucutureService = currencyInfraestrucutureService;
		}
		public async Task<IEnumerable<EntityCurrency>> GetAllCurrenciesAsync()
		{
			var currency = await _currencyInfraestrucutureService.GetAllAsync();
			return currency;
		}
		public async Task<EntityCurrency> GetCurrencyByIdAsync(int id)
		{
			var currencyGuid = await _currencyInfraestrucutureService.GetByIdAsync(id);
			return currencyGuid;
		}
		public async Task CreateCurrencyAsync(EntityCurrency currency)
		{
			await _currencyInfraestrucutureService.AddAsync(currency);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task UpdateCurrencyAsync(EntityCurrency currency)
		{
			await _currencyInfraestrucutureService.UpdateAsync(currency);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteCurrencyAsync(int id)
		{
			await _currencyInfraestrucutureService.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
