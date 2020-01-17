using APIBackPart.Model;
using Microsoft.EntityFrameworkCore;


namespace APIBackPart.DAL
{
    public class BackPartContext : DbContext
    {
        public BackPartContext(DbContextOptions<BackPartContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Category>().HasIndex("Name").IsUnique();
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Dress"},
                new Category { Id = 2, Name = "Shoes" },
                new Category { Id = 3, Name = "Electronics" },
                new Category { Id = 4, Name = "Furniture" }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Adidas T-shirt", Price= 100, CategoryId = 1 },
                new Product { Id = 2, Name = "Nike T-shirt", Price= 89, CategoryId = 1 },
                new Product { Id = 3, Name = "Skirt Long", Price = 70, CategoryId = 1 },
                new Product { Id = 4, Name = "Adidas shoes", Price = 60, CategoryId = 2 },
                new Product { Id = 5, Name = "Nike shoes", Price = 77, CategoryId = 2 },
                new Product { Id = 6, Name = "Iphone 10", Price = 1000, CategoryId = 3 },
                new Product { Id = 7, Name = "Sofa", Price = 5000, CategoryId = 4},
                new Product { Id = 8, Name = "Chair", Price = 300, CategoryId = 4 }
                );
        }
    }
}
