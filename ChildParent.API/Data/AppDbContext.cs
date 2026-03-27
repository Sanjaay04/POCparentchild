using Microsoft.EntityFrameworkCore;
using ChildParent.API.Model;
namespace ChildParent.API.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
