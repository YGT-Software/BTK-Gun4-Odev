using Microsoft.EntityFrameworkCore;

namespace KitaplarOdevCodeFirst.Models
{
    public class KitaplarDbContext : DbContext
    {
        public KitaplarDbContext(DbContextOptions<KitaplarDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
    }
}
