using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class InMemoryDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("JakeDb");
    }

    public DbSet<Data.Customer> Customers { get; set; } = null!;
    public DbSet<Data.Business> Businesses { get; set; } = null!;
    public DbSet<Data.Verification> Verifications { get; set; } = null!;
    public DbSet<Data.CustomerSession> CustomerSessions { get; set; } = null!;
    public DbSet<Data.Employee> Employees { get; set; } = null!;
    public DbSet<Data.BusinessLocation> BusinessLocations { get; set; } = null!;
    public DbSet<Data.Category> Categories { get; set; }
}