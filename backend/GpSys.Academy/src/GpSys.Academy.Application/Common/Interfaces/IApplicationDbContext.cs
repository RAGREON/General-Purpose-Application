namespace GpSys.Academy.Application.Common.Interfaces
{
  public interface IApplicationDbContext
  {
    DbSet<Course> Courses { get; }

    Task<int> SaveChangesAsync(CancellationToken token);
  }
}