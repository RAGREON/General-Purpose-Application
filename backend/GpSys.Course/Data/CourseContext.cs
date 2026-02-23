namespace GpSys.Course.Data
{
  public class CourseContext(DbContextOptions<CourseContext> options) : DbContext(options)
  {
    public DbSet<CourseEntity> Courses => Set<CourseEntity>();

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   modelBuilder.Entity<CourseEntity>()
    //     .HasKey(c => c.Id);

    //   modelBuilder.Entity<CourseEntity>()
    //     .HasIndex(c => c.Code)
    //     .IsUnique();
    // }
  }
}