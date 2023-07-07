using LiteDB;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class LiteDbCategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;

        public LiteDbCategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<EntityCategory>> GetAllAsync()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var categoryCollection = db.GetCollection<Category>("Category");
                var categories = categoryCollection.FindAll().ToList();
                return categories.Select(c => new EntityCategory
                {
                    Id = c.Id_Category,
                    Name = c.Name,
                    Description = c.Description,
                    UrlWeb = c.UrlWeb
                });
            }
        }

        public async Task<EntityCategory> GetByIdAsync(Guid id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var categoryCollection = db.GetCollection<Category>("Category");
                var category = categoryCollection.FindById(id);
                if (category != null)
                {
                    return new EntityCategory
                    {
                        Id = category.Id_Category,
                        Name = category.Name,
                        Description = category.Description,
                        UrlWeb = category.UrlWeb
                    };
                }
                return null;
            }
        }

        public async Task AddAsync(EntityCategory category)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var categoryCollection = db.GetCollection<Category>("Category");
                var newCategory = new Category
                {
                    Id_Category = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    UrlWeb = category.UrlWeb
                };
                categoryCollection.Insert(newCategory);
            }
        }

        public async Task UpdateAsync(EntityCategory category)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var categoryCollection = db.GetCollection<Category>("Category");
                var existingCategory = categoryCollection.FindById(category.Id);
                if (existingCategory != null)
                {
                    existingCategory.Name = category.Name;
                    existingCategory.Description = category.Description;
                    existingCategory.UrlWeb = category.UrlWeb;
                    categoryCollection.Update(existingCategory);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var categoryCollection = db.GetCollection<Category>("Category");
                categoryCollection.Delete(id);
            }
        }
    }
}
