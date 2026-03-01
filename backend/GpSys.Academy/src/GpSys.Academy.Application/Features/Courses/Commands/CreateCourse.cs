
namespace GpSys.Academy.Application.Features.Courses
{
  public record CreateCourseCommand(string Code, string Title, string Alias) : IRequest<Result<Guid>>;

  public class CreateCourseHandler(IApplicationDbContext context) 
    : IRequestHandler<CreateCourseCommand, Result<Guid>>
  {
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<Guid>> Handle(CreateCourseCommand command, CancellationToken token)
    {
      var result = Course.Create(command.Code, command.Title, command.Alias);

      if (!result.IsSuccess)
        return Result<Guid>.Failure(result.Errors);

      var course = result.Value!;
      _context.Courses.Add(course);
      await _context.SaveChangesAsync(token);

      return Result<Guid>.Success(course.Id);
    }
  }
}