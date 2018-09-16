using Microsoft.EntityFrameworkCore;

namespace Restauranter.Models
{
    public class YourContext : DbContext
    {
        public YourContext(DbContextOptions<YourContext> options) : base(options) {}
        public DbSet<Review> Reviews { get; set; } 
    }
}