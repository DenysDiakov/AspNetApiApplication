using Microsoft.EntityFrameworkCore;

namespace MyTask.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ShoppingCart> Cart { get; set; }


        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product() { Id = 1, Name = "Samsung s9 plus", Price = 30000 },
                    new Product() { Id = 2, Name = "Iphone X", Price = 25000 },
                    new Product() { Id = 3, Name = "Windows Phone", Price = 11000 },
                    new Product() { Id = 4, Name = "Asus ROG Phone", Price = 15000 },
                    new Product() { Id = 5, Name = "Xiaomi", Price = 9000 },
                    new Product() { Id = 6, Name = "Nokia 3310", Price = 500 }
                }

            );
        }
    }
}

