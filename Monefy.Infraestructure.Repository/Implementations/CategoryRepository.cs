using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.DataModels;
using Monefy.Business.RepositoryContracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class CategoryRepository : GenericRepository<EntityCategory> , ICategoryRepository
    {
       // private readonly CategoryContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(DataBaseContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntityCategory>> GetAllAsync()
        {
            var categoryDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityCategory>>(categoryDataModels);
        }

        public async Task<EntityCategory> GetByIdAsync(Guid id)
        {
            var categoryDataModels = await base.GetByIdAsync(id);
            return _mapper.Map<EntityCategory>(categoryDataModels);
        }

        public async Task AddAsync(EntityCategory category)
        {
            var categoryDataModels = _mapper.Map<EntityCategory>(category);
            await base.AddAsync(categoryDataModels);
        }

        public async Task UpdateAsync(EntityCategory category)
        {
            var categoryDataModels = _mapper.Map<EntityCategory>(category);
            await base.UpdateAsync(categoryDataModels);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
}



