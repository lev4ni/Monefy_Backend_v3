using AutoMapper;
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

        public CategoryRepository(IMapper mapper, DataBaseContext context) : base(context)
        {
            _mapper = mapper;
        }

        public new async Task<IEnumerable<EntityCategory>> GetAllAsync()
        {
            var categoryDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityCategory>>(categoryDataModels);
        }

        public new async Task<EntityCategory> GetByIdAsync(int id)
        {
            var categoryDataModels = await base.GetByIdAsync(id);
            return _mapper.Map<EntityCategory>(categoryDataModels);
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
    }
}



