namespace GpSys.Academy.Application.Features.Courses
{
  public record UpdateCourseCommand(
    Guid Id, 
    string? Code,
    string? Title,
    string? Alias) : IRequest<Result<bool>>;

  public class UpdateCourseHandler(IApplicationDbContext context) 
    : IRequestHandler<UpdateCourseCommand, Result<bool>>
  {
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<bool>> Handle(UpdateCourseCommand command, CancellationToken token)
    {
      var course = await _context.Courses
        .FirstOrDefaultAsync(c => c.Id == command.Id, token);

      if (course is null) 
        return Result<bool>.Failure($"Invalid Id: {command.Id}");

      var result = course.Update(command.Code, command.Title, command.Alias);

      if (!result.IsSuccess)
        return Result<bool>.Failure(result.Errors);

      await _context.SaveChangesAsync(token);

      return Result<bool>.Success(true);
    }
  }
}