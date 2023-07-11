using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class CurrencyBusinessService : ICurrencyBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICurrencyRepository _currencyRepository;
		public CurrencyBusinessService(IUnitOfWork unitOfWork, ICurrencyRepository currencyRepository)
		{
			_unitOfWork = unitOfWork;
			_currencyRepository = currencyRepository;
		}
		public async Task<IEnumerable<EntityCurrency>> GetAllCurrenciesAsync()
		{
			var currency = await _currencyRepository.GetAllAsync();
			return currency;
		}
		public async Task<EntityCurrency> GetCurrencyByIdAsync(int id)
		{
			var currencyGuid = await _currencyRepository.GetByIdAsync(id);
			return currencyGuid;
		}
		public async Task CreateCurrencyAsync(EntityCurrency currency)
		{
			await _currencyRepository.AddAsync(currency);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task UpdateCurrencyAsync(EntityCurrency currency)
		{
			await _currencyRepository.UpdateAsync(currency);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteCurrencyAsync(int id)
		{
			await _currencyRepository.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
