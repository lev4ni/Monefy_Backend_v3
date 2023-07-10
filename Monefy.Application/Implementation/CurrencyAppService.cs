using AutoMapper;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Application.Implementation
{
    public class CurrencyAppService : ICurrencyAppService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyBusinessService _currencyBusinessService;
        public CurrencyAppService(IMapper mapper, ICurrencyBusinessService currencyBusinessService)
        {
            _mapper = mapper;
            _currencyBusinessService = currencyBusinessService;
        }

        public async Task<CurrencyDTO> CreateCurrencyAsync(CurrencyDTO currencyDTO)
        {
            await _currencyBusinessService.CreateCurrencyAsync(_mapper.Map<EntityCurrency>(currencyDTO));
            return currencyDTO;
        }

        public async Task<IEnumerable<CurrencyDTO>> GetAllCurrenciesAsync()
        {
            var currencyList = await _currencyBusinessService.GetAllCurrenciesAsync();
            return _mapper.Map<IEnumerable<CurrencyDTO>>(currencyList);
        }

        public async Task<CurrencyDTO> GetCurrencyByIdAsync(int id)

        {
            var currency = await _currencyBusinessService.GetCurrencyByIdAsync(id);
            return _mapper.Map<CurrencyDTO>(currency);
        }

        public async Task<CurrencyDTO> UpdateCurrencyAsync(CurrencyDTO currencyDTO)
        {
            await _currencyBusinessService.UpdateCurrencyAsync(_mapper.Map<EntityCurrency>(currencyDTO));
            return currencyDTO;
        }

        public async Task<CurrencyDTO> DeleteCurrencyAsync(int id)
        {
            await _currencyBusinessService.DeleteCurrencyAsync(id);
            return _mapper.Map<CurrencyDTO>(id);
        }
    }
}
