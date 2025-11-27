using hwWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace hwWebAPI.Data
{
    public class BigBiteContext:DbContext
    {
        public BigBiteContext(DbContextOptions<BigBiteContext> options):base(options) { }
     
        public DbSet<Product> Products =>Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();
        public DbSet<CategoryEnum> CategoriesEnum => Set<CategoryEnum>();
        public DbSet<Basket> Baskets => Set<Basket>();

    }
}
