using KVMClothStore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KVMClothStore.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        //“My database has a table called Products and each row follows the Product class structure.”
        public DbSet<Product> Products => Set<Product>();

        //“My database has a table called categories and each row follows the Category class structure.”
        public DbSet<Category> categories => Set<Category>();
    }
}
