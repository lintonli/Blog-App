using Microsoft.EntityFrameworkCore;
using POSTSS.Models;

namespace POSTSS.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }

       public DbSet<Post> Posts {  get; set; }
        public DbSet<PostImage> PostImages {  get; set; }
    }
}
