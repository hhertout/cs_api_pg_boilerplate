using Microsoft.EntityFrameworkCore;
using Models;

namespace Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<PostModel> Posts { get; set; }
    }
}
