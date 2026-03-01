using GpSys.Academy.Domain.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GpSys.Academy.Infrastructure.Data.Interceptors
{
  public class AuditableEntityInterceptor : SaveChangesInterceptor
  {
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
      UpdateEntities(eventData.Context);
      return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken token = default)
    {
      UpdateEntities(eventData.Context);
      return base.SavingChangesAsync(eventData, result, token);
    }

    private static void UpdateEntities(DbContext? context)
    {
      if (context is null) return;

      var now = DateTime.UtcNow;
      var user = "System";

      foreach (var entity in context
        .ChangeTracker
        .Entries<AuditableBaseEntity>())
      {
        switch (entity.State) {
          case EntityState.Added:
            entity.Entity.MarkCreated(now, user);
            break;

          case EntityState.Modified:
            entity.Entity.MarkUpdated(now, user);
            break;
          
          case EntityState.Deleted:
            entity.State = EntityState.Modified;
            entity.Entity.SoftDelete(now, user);
            break;
        }        
      }
    }
  }
}