using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Domain.Implementation
{
    public class IncomeBusinessService : IIncomeBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IncomeBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EntityIncome>> GetAllIncomesAsync()
        {
            var income = await _unitOfWork.IncomeRepository.GetAllAsync();
            await _unitOfWork.SaveChangesAsync();
            return income;
        }

        public async Task<EntityIncome> GetIncomeByIdAsync(Guid guid)
        {
            var income = await _unitOfWork.IncomeRepository.GetByIdAsync(guid);
            await _unitOfWork.SaveChangesAsync();
            return income;
        }
        public async Task CreateIncomeAsync(EntityIncome income)
        {
            await _unitOfWork.IncomeRepository.AddAsync(income);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateIncomeAsync(EntityIncome income)
        {
            await _unitOfWork.IncomeRepository.UpdateAsync(income);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteIncomeAsync(Guid id)
        {
           await _unitOfWork.IncomeRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
