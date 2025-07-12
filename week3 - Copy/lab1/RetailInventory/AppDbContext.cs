using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace this with your actual connection string
        optionsBuilder.UseSqlServer("Server=localhost;Database=RetailDb;Trusted_Connection=True;");
    }
}
