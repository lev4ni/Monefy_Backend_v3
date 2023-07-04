﻿using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Expense> _genericRepository;
        private readonly DataBaseContext _dataBaseContext;

        public ExpenseRepository(IMapper mapper, IGenericRepository<Expense> genericRepository, DataBaseContext context)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dataBaseContext = context;
        }
        public async Task<IEnumerable<EntityExpense>> GetAllAsync()
        {
            var expenseDataModels = await _genericRepository.GetAllAsync( _dataBaseContext);
            return _mapper.Map<IEnumerable<EntityExpense>>(expenseDataModels);
        }

        public async Task<EntityExpense> GetByIdAsync(Guid id)
        {
            var expensetDataModel = await _genericRepository.GetByIdAsync(id, _dataBaseContext);
            return _mapper.Map<EntityExpense>(expensetDataModel);
        }

        public async Task AddAsync(EntityExpense expense)
        {
            var expensetDataModel = _mapper.Map<Expense>(expense);
            await _genericRepository.AddAsync(expensetDataModel, _dataBaseContext);
        }

        public async Task UpdateAsync(EntityExpense expense)
        {
            var expensetDataModel = _mapper.Map<Expense>(expense);
            await _genericRepository.UpdateAsync(expensetDataModel, _dataBaseContext);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id, _dataBaseContext);
        }
    }
 
}
