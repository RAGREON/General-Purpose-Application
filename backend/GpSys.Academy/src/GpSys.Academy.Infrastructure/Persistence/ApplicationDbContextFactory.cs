using Microsoft.EntityFrameworkCore.Design;

namespace GpSys.Academy.Infrastructure.Persistence
{
  public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
  {
    public ApplicationDbContext CreateDbContext(string[] args)
    {
      DotNetEnv.Env.Load();

      string connectionString = Environment.GetEnvironmentVariable("MigrationString") ?? "";

      var options = new DbContextOptionsBuilder<ApplicationDbContext>();
      options.UseNpgsql(connectionString);

      return new ApplicationDbContext(options.Options);
    }
  }
}