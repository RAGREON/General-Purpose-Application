using Microsoft.EntityFrameworkCore.Design;

namespace Lab.Data
{
  public class LabContextFactory : IDesignTimeDbContextFactory<LabContext>
  {
    public LabContext CreateDbContext(string[] args)
    {
      DotNetEnv.Env.Load();

      string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
      string name = Environment.GetEnvironmentVariable("DB_NAME") ?? "MigrationBuildOnly";
      string user = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
      string pass = Environment.GetEnvironmentVariable("DB_PASS") ?? "";

      var optionsBuilder = new DbContextOptionsBuilder<LabContext>();
      optionsBuilder.UseNpgsql($"Host={host};Database={name};Username={user};Password={pass}");

      return new LabContext(optionsBuilder.Options);
    }
  }
}