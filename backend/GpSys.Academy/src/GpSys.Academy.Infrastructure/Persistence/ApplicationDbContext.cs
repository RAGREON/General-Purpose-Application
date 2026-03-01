using GpSys.Academy.Application.Common.Interfaces;
using GpSys.Academy.Infrastructure.Data.Interceptors;

namespace GpSys.Academy.Infrastructure.Persistence
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext 
  {
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.AddInterceptors(new AuditableEntityInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

      modelBuilder.Entity<Course>().HasQueryFilter(c => !c.IsDeleted);
    }
  }
}