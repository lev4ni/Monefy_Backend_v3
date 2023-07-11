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
        private readonly IUnitOfWork _unitOfWork;

        public CategoryRepository(IMapper mapper, DataBaseContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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
    }
}



