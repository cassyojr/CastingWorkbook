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
        //modelBuilder.Entity<User>().HasMany(x => x.Favorites).WithOne(x => x.);
        //modelBuilder.Entity<Project>().HasMany(x => x.Jobs).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId).IsRequired();
        //modelBuilder.Entity<Job>().HasOne(x => x.Project).WithMany(x => x.Jobs).HasForeignKey(x => x.ProjectId);

        //modelBuilder.Entity<User>().HasData(UserSeeds.Data);
        //modelBuilder.Entity<Project>().HasData(ProjectSeeds.Data);
        //modelBuilder.Entity<Job>().HasData(JobSeeds.Data);
        //modelBuilder.Entity<Favorite>().HasData(FavoriteSeeds.Data);

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
