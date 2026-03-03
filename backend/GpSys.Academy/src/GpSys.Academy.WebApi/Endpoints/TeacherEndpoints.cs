using GpSys.Academy.Application.Features.Teachers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GpSys.Academy.WebApi.Endpoints 
{
  public static class TeacherEndpoints
  {
    public static void MapTeacherEndpoints(this IEndpointRouteBuilder app)
    {
      var group = app.MapGroup("/api/teachers")
        .WithTags("Teachers");

      group.MapPost("/", async (CreateTeacherCommand request, IMediator mediator) =>
      {
        var result = await mediator.Send(request);

        if (!result.IsSuccess)
          return Results.BadRequest(new
          {
            result.ErrorMessage,
            result.Errors
          });
        
        return Results.Ok(result.Value);
      });

      group.MapPut("/", async (UpdateTeacherCommand request, IMediator mediator) =>
      {
        var result = await mediator.Send(request);

        if (!result.IsSuccess) 
          return Results.BadRequest(new
          {
            result.ErrorMessage,
            result.Errors
          });

        return Results.Ok(result.Value);
      });

      group.MapDelete("/", async ([FromBody] DeleteTeacherCommand request, IMediator mediator) =>
      {
        var result = await mediator.Send(request);

        if (!result.IsSuccess) 
          return Results.BadRequest(new
          {
            result.ErrorMessage,
            result.Errors
          });

        return Results.Ok(result.Value);
      });

      group.MapGet("/", async ([FromQuery] Guid id , IMediator mediator) =>
      {
        var result = await mediator.Send(new GetTeacherQuery(id));

        if (!result.IsSuccess) 
          return Results.BadRequest(new
          {
            result.ErrorMessage,
            result.Errors
          });

        return Results.Ok(result.Value);
      });

      group.MapGet("/all", async ([AsParameters] GetTeachersQuery request, IMediator mediator) =>
      {
        var result = await mediator.Send(request);

        return Results.Ok(result.Value);
      });
    }
  }
}