namespace GpSys.Academy.Application.Common.Interfaces
{
  public interface IDbInitializer
  {
    Task SeedAsync(int count);
    Task ClearAsync();
    Task ResetAsync(int count);
  }
}