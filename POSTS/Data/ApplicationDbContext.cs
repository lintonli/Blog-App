using Microsoft.EntityFrameworkCore;
using POSTS.Models;

namespace POSTS.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }
       public DbSet<Post>Posts { get; set; }
    }
}
