#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace Products_and_Categories.Models;
public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<Categories> Categories { get; set; } 
    public DbSet<Products> Products { get; set; } 
    public DbSet<Assossiations> Assossiations { get; set; } 
}