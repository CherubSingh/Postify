using Postify.API.Models.Domain;

namespace Postify.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(Guid id);

        Task<Category?> UpdateAsync(Category category);
    }
}
