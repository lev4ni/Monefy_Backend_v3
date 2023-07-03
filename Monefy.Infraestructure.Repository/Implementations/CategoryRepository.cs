using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.DataModels;
using Monefy.Business.RepositoryContracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
       // private readonly CategoryContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(CategoryContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categoryDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<Category>>(categoryDataModels);
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var categoryDataModels = await base.GetByIdAsync(id);
            return _mapper.Map<Category>(categoryDataModels);
        }

        public async Task AddAsync(Category category)
        {
            var categoryDataModels = _mapper.Map<Category>(category);
            await base.AddAsync(categoryDataModels);
        }

        public async Task UpdateAsync(Category category)
        {
            var categoryDataModels = _mapper.Map<Category>(category);
            await base.UpdateAsync(categoryDataModels);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
}



