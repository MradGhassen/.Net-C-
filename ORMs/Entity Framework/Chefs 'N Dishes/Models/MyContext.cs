#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ChefsDishes.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }

    public DbSet<Dishe> Dishes { get; set; }
    public DbSet<Chef> Chefs { get; set; }
}