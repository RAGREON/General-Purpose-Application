using GpSys.Academy.Application.Features.Courses;
using MediatR;

namespace GpSys.Academy.Api.Endpoints
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
        return result;
      });

      group.MapDelete("/{id}", async (Guid id, IMediator m) =>
      {
        var result = await m.Send(new DeleteCourseCommand(id));
        return result;
      });

      group.MapPut("/", async (UpdateCourseCommand cmd, IMediator m) =>
      {
        var result = await m.Send(cmd);
        return result;
      });

      group.MapGet("/{id}", async (Guid id, IMediator m) =>
      {
        var result = await m.Send(new GetCourseByIdQuery(id));
        return result;
      });

      group.MapGet("/all", async (IMediator m) =>
      {
        var result = await m.Send(new GetCoursesQuery());
        return result;
      });
    }
  }
}