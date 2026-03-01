using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GpSys.Academy.Infrastructure.Data.Configurations
{
  public class CourseConfiguration : IEntityTypeConfiguration<Course>
  {
    public void Configure(EntityTypeBuilder<Course> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Code) 
        .IsRequired()
        .HasMaxLength(20);

      builder.HasIndex(x => x.Code).IsUnique();

      builder.Property(x => x.Title)
        .IsRequired()
        .HasMaxLength(200);
    }
  }
}