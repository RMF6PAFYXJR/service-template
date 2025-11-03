using Microsoft.EntityFrameworkCore;
using service_template.Models;

namespace service_template.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(x => x.Id);
    }
}