using Microsoft.EntityFrameworkCore;
using Postify.API.Data;
using Postify.API.Models.Domain;
using Postify.API.Repositories.Interface;

namespace Postify.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly ApplicationDBContext dbContext;
        public CategoryRepository(ApplicationDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }
    }
}
