using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Domain.Implementation
{
    public class CurrencyBusinessService : ICurrencyBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CurrencyBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EntityCurrency>> GetAllCurrenciesAsync()
        {
            var currency = await _unitOfWork.CurrencyRepository.GetAllAsync();
            await _unitOfWork.SaveChangesAsync();
            return currency;
        }
        public async Task<EntityCurrency> GetCurrencyByIdAsync(Guid guid)
        {
            var currencyGuid = await _unitOfWork.CurrencyRepository.GetByIdAsync(guid);
            await _unitOfWork.SaveChangesAsync();
            return currencyGuid;
        }
        public async Task CreateCurrencyAsync(EntityCurrency currency)
        {
            await _unitOfWork.CurrencyRepository.AddAsync(currency);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCurrencyAsync(EntityCurrency currency)
        {
            await _unitOfWork.CurrencyRepository.UpdateAsync(currency);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteCurrencyAsync(Guid id)
        {
            await _unitOfWork.CurrencyRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
