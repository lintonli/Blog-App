using Microsoft.EntityFrameworkCore;
using POSTSERVICE.Models;

namespace POSTSERVICE.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
       
        public DbSet<Post> Posts {  get; set; }
    }
}
