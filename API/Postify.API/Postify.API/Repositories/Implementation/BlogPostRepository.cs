using Postify.API.Repositories.Interface;
using Postify.API.Models.Domain;
using Postify.API.Data;

namespace Postify.API.Repositories.Implementation
{
    public class BlogPostRepository: IBlogPostRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public BlogPostRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await _dbContext.BlogPosts.AddAsync(blogPost);
            await _dbContext.SaveChangesAsync();
            return blogPost;
        }
    }
}
