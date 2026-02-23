using Microsoft.VisualBasic;

namespace Lab.Data
{
  public class LabContext(DbContextOptions<LabContext> options) : DbContext(options) {
    public DbSet<LabEntity> Labs => Set<LabEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<LabEntity>()
        .Property<DateTime>("CreatedAt")
        .HasDefaultValueSql("now()");
      
      modelBuilder.Entity<LabEntity>()
        .Property<DateTime>("UpdatedAt")
        .HasDefaultValueSql("now()");
      
      modelBuilder.Entity<LabEntity>()
        .Property<bool>("IsDeleted")
        .HasDefaultValue(false);

      modelBuilder.Entity<LabEntity>()
        .HasQueryFilter(l => !EF.Property<bool>(l, "IsDeleted"));
    }

    public override int SaveChanges()
    {
      var now = DateTime.UtcNow;

      foreach (var entity in ChangeTracker.Entries()
                   .Where(e => e.State == EntityState.Modified))
      {
        if (entity.Properties.Any(p => p.Metadata.Name == "UpdatedAt"))
        {
          entity.Property("UpdatedAt").CurrentValue = now;
        }
      }

      return base.SaveChanges();
    }
  }
}