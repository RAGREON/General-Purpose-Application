namespace Lab.Data
{
  public class LabContext(DbContextOptions<LabContext> options) : DbContext(options) {
    public DbSet<LabEntity> Labs => Set<LabEntity>();
  }
}