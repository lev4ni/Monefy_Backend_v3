using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Application.DTOs;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.services;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataBaseContext _dataBaseContext;

        public CategoryRepository(IMapper mapper, DataBaseContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dataBaseContext = context;
        }

        public new async Task<IEnumerable<EntityCategory>> GetAllAsync()
        {
            var categoryDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityCategory>>(categoryDataModels);
        }

        public new async Task<EntityCategory> GetByIdAsync(int id)
        {
            var categoryDataModels = await base.GetByIdAsync(id);
            var category = _mapper.Map<EntityCategory>(categoryDataModels);
            return category;
        }

        public async Task AddAsync(EntityCategory category)
        {
            var categoryDataModels = _mapper.Map<Category>(category);
            await base.AddAsync(categoryDataModels);
        }

        public async Task UpdateAsync(EntityCategory category)
        {
            var categoryDataModels = _mapper.Map<Category>(category);
            await base.UpdateAsync(categoryDataModels);
        }

        public async Task<IEnumerable<EntityCategoryWithExpenses>> GetCategoriesWithExpenses(int walletId, DateTime initialDate, DateTime finalDate)
        {
            //Falta el await
            var categoriesWithExpenses = await _dataBaseContext.Category
        .Join(_dataBaseContext.Expenses,
            category => category.Id,
            expense => expense.CategoryId,
            (category, expense) => new { Category = category, Expense = expense })
        .Where(c => c.Expense.WalletId == walletId
                    && c.Expense.CreatedAt >= initialDate
                    && c.Expense.CreatedAt <= finalDate)
        .GroupBy(c => c.Category)
        .Select(group => new EntityCategoryWithExpenses
        {
            Category = _mapper.Map<EntityCategory>(group.Key),
            Expenses = (IEnumerable<EntityExpense>)group.Select(c => c.Expense).ToList()
        })
        .ToListAsync();

            return _mapper.Map<IEnumerable<EntityCategoryWithExpenses>>(categoriesWithExpenses);

        }
    }
}
