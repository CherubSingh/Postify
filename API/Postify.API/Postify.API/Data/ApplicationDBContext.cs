using Microsoft.EntityFrameworkCore;
using Postify.API.Models.Domain;

namespace Postify.API.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
