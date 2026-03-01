namespace GpSys.Academy.Application.Features.Courses
{
  public record DeleteCourseCommand(Guid Id) : IRequest<Result<bool>>;

  public class DeleteCourseHandler(IApplicationDbContext context) 
    : IRequestHandler<DeleteCourseCommand, Result<bool>>
  {
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<bool>> Handle(DeleteCourseCommand command, CancellationToken token)
    {
      var course = await _context.Courses
        .FirstOrDefaultAsync(c => c.Id == command.Id, token);

      if (course is null)
        return Result<bool>.Failure($"Invalid Id: {command.Id}");

      _context.Courses.Remove(course);
      await _context.SaveChangesAsync(token);

      return Result<bool>.Success(true);
    }
  }
}