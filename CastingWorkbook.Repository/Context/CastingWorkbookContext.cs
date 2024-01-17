using CastingWorkbook.Repository.Configuration;
using CastingWorkbook.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CastingWorkbook.Repository.Context;

public class CastingWorkbookContext : DbContext
{
    public CastingWorkbookContext(DbContextOptions<CastingWorkbookContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "CastingWorkbook");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new JobConfiguration());
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
}
