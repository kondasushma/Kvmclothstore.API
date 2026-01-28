using KVMClothStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace KVMClothStore.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> categories => Set<Category>();
    }
}
