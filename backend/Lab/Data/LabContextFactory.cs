using Microsoft.EntityFrameworkCore.Design;

namespace Lab.Data
{
  public class LabContextFactory : IDesignTimeDbContextFactory<LabContext>
  {
    public LabContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<LabContext>();
      optionsBuilder.UseNpgsql("Host=localhost;Database=MigrationBuildOnly;");
      return new LabContext(optionsBuilder.Options);
    }
  }
}