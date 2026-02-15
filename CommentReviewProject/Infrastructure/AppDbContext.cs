using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure;
public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Message> Messages => Set<Message>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasMany<Message>()
        .WithOne()
        .HasForeignKey("UserId")
        .OnDelete(DeleteBehavior.Cascade);


    }
}