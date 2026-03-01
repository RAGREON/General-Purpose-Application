using GpSys.Academy.Application.Features.Courses;
using MediatR;

namespace GpSys.Academy.WebApi.Endpoints
{
  public static class CourseEndpoints
  {
    public static void MapCourseEndpoints(this IEndpointRouteBuilder app)
    {
      var group = app.MapGroup("/api/courses")
        .WithTags("Courses");

      group.MapPost("/", async (CreateCourseCommand cmd, IMediator m) =>
      {
        var result = await m.Send(cmd);

        if (!result.IsSuccess)
          return Results.BadRequest(new
          {
            result.ErrorMessage,
            result.Errors
          });

        return Results.Ok(result.Value);
      });

      group.MapDelete("/{id}", async (Guid id, IMediator m) =>
      {
        var result = await m.Send(new DeleteCourseCommand(id));

        if (!result.IsSuccess)
          return Results.InternalServerError(new
          {
            result.ErrorMessage,
            result.Errors
          });

        return Results.Ok(result.Value);
      });

      group.MapPut("/", async (UpdateCourseCommand cmd, IMediator m) =>
      {
        var result = await m.Send(cmd);

        if (!result.IsSuccess)
          return Results.InternalServerError(new
          {
            result.ErrorMessage,
            result.Errors
          });

        return Results.Ok(result.Value);
      });

      group.MapGet("/{id}", async (Guid id, IMediator m) =>
      {
        var result = await m.Send(new GetCourseByIdQuery(id));

        if (!result.IsSuccess)
          return Results.BadRequest(new
          {
            result.ErrorMessage,
            result.Errors
          });
        
        return Results.Ok(result.Value);
      });

      group.MapGet("/all", async (IMediator m) =>
      {
        var result = await m.Send(new GetCoursesQuery());

        return Results.Ok(result.Value);
      });
    }
  }
}