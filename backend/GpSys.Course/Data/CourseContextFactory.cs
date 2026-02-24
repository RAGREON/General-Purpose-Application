using Microsoft.EntityFrameworkCore.Design;

namespace GpSys.Course.Data
{
  public class CourseContextFactory : IDesignTimeDbContextFactory<CourseContext>
  {
    public CourseContext CreateDbContext(string[] args)
    {
      DotNetEnv.Env.Load();

      string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
      string name = Environment.GetEnvironmentVariable("DB_NAME") ?? "MigrationBuildOnly";
      string user = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
      string pass = Environment.GetEnvironmentVariable("DB_PASS") ?? "";

      var optionsBuilder = new DbContextOptionsBuilder<CourseContext>(); optionsBuilder.UseNpgsql($"Host={host};Database={name};Username={user};Password={pass}");

      return new CourseContext(optionsBuilder.Options);
    }
  }
}