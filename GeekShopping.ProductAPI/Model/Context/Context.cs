using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Camiseta Polo",
                Price = new decimal(69.9),
                Description = "Polo",
                ImageURL = "polo_image_url.jpg",
                CategoryName = "T-Shirt",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Camiseta Básica",
                Price = new decimal(49.9),
                Description = "Camiseta básica de algodão",
                ImageURL = "basic_tee_image_url.jpg",
                CategoryName = "T-Shirt",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Jaqueta Esportiva",
                Price = new decimal(99.9),
                Description = "Jaqueta para atividades esportivas",
                ImageURL = "sport_jacket_image_url.jpg",
                CategoryName = "Outerwear",
            });
        }
    }
}