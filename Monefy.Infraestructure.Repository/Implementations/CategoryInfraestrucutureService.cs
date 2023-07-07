using AutoMapper;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.DataModels;
using Monefy.Business.RepositoryContracts;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class CategoryInfraestrucutureService : ICategoryInfraestrucutureService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly DataBaseContext _dataBaseContext;

        public CategoryInfraestrucutureService(IMapper mapper, IGenericRepository<Category> genericRepository, DataBaseContext context)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dataBaseContext = context;
        }

        public async Task<IEnumerable<EntityCategory>> GetAllAsync()
        {
            var categoryDataModels = await _genericRepository.GetAllAsync(_dataBaseContext);
            return _mapper.Map<IEnumerable<EntityCategory>>(categoryDataModels);
        }

        public async Task<EntityCategory> GetByIdAsync(Guid id)
        {
            var categoryDataModels = await _genericRepository.GetByIdAsync(id, _dataBaseContext);
            return _mapper.Map<EntityCategory>(categoryDataModels);
        }

        public async Task AddAsync(EntityCategory category)
        {
            var categoryDataModels = _mapper.Map<Category>(category);
            await _genericRepository.AddAsync(categoryDataModels,_dataBaseContext);
        }

        public async Task UpdateAsync(EntityCategory category)
        {
            var categoryDataModels = _mapper.Map<Category>(category);
            await _genericRepository.UpdateAsync(categoryDataModels, _dataBaseContext);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id, _dataBaseContext);
        }
    }
}



