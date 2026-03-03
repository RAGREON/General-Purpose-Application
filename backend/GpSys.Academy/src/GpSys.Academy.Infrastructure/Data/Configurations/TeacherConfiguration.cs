using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GpSys.Academy.Infrastructure.Data.Configurations
{
  public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
  {
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
      builder.HasKey(x => x.Id);
    }
  }
}