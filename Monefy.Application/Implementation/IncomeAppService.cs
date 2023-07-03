using AutoMapper;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Domain.Contracts;
using Monefy.Domain.Implementation;
using Monefy.Entities;

namespace Monefy.Application.Implementation
{
    public class IncomeAppService : IIncomeAppService
    {
        private readonly IMapper _mapper;
        private readonly IIncomeBusinessService _incomeBusinessService;
        public IncomeAppService(IMapper mapper, IIncomeBusinessService incomeBusinessService)
        {
            _mapper = mapper;
            _incomeBusinessService = incomeBusinessService;
        }

        public async Task CreateIncomeAsync(IncomeDTO incomeDTO)
        {
            await _incomeBusinessService.CreateIncomeAsync(_mapper.Map<Income>(incomeDTO));
        }

        public async Task DeleteIncomeAsync(Guid id)
        {
            await _incomeBusinessService.DeleteIncomeAsync(id);
        }

        public async Task<IEnumerable<IncomeDTO>> GetAllIncomesAsync()
        {
            var incomeList = await _incomeBusinessService.GetAllIncomesAsync();
            return _mapper.Map<IEnumerable<IncomeDTO>>(incomeList);
        }

        public async Task<IncomeDTO> GetIncomeByIdAsync(Guid id)
        {
            var income = await _incomeBusinessService.GetIncomeByIdAsync(id);
            return _mapper.Map<IncomeDTO>(income);
        }

        public async Task UpdateIncomeAsync(IncomeDTO incomeDTO)
        {
            await _incomeBusinessService.UpdateIncomeAsync(_mapper.Map<Income>(incomeDTO));
        }
    }
}
