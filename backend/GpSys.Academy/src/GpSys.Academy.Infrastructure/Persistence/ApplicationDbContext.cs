namespace GpSys.Academy.Infrastructure.Persistence
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) 
  {
    public DbSet<Course> Courses => Set<Course>();
  }
}