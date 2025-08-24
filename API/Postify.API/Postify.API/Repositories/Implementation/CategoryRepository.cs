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

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory=await dbContext.Categories.FirstOrDefaultAsync(x=>x.Id==id);

            if(existingCategory == null)
            {
                return null;
            }

            dbContext.Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();

            return existingCategory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if(existingCategory!=null)
            {
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
