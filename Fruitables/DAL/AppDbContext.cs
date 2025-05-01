using Fruitables.Models;
using Microsoft.EntityFrameworkCore;

namespace Fruitables.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Slides { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}

