namespace GpSys.Teacher.Data
{
  public class TeacherContext(DbContextOptions options) : DbContext(options)
  {
    public DbSet<TeacherEntity> Teachers => Set<TeacherEntity>();
  }
}