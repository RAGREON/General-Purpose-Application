using GpSys.Academy.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GpSys.Academy.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg, string connStr = "DefaultConn")
    {
      services.AddDbContext<ApplicationDbContext>(options =>
      {
        options.UseNpgsql(cfg.GetConnectionString(connStr));
      });
      
      return services;
    }
  }
}