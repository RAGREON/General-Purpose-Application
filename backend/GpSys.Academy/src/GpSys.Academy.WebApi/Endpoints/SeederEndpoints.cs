using GpSys.Academy.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GpSys.Academy.WebApi.Endpoints
{
  public static class SeederEndpoints
  {
    public static void MapSeederEndpoints(this IEndpointRouteBuilder app)
    {
      var group = app.MapGroup("/api/seeder")
        .WithTags("Seeder");

      group.MapPost("/course/seed", async ([FromQuery] int count, IDbInitializer db) =>
      {
        await db.SeedAsync(count);
        return "completed seeding";
      });

      group.MapPost("/course/clear", async (IDbInitializer db) =>
      {
        await db.ClearAsync();
        return "cleared database";
      });

      group.MapPost("/course/reset", async ([FromQuery] int count, IDbInitializer db) =>
      {
        await db.ResetAsync(count);
        return "reset database";
      });
    }
  }
}