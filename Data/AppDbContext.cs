using Microsoft.EntityFrameworkCore;
using RentApi.Models;

namespace RentApi.Data
{
    public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Payment> Payments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    }
}