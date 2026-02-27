namespace GpSys.Academy.Application.Features.Courses
{
  public record UpdateCourseCommand(
    Guid Id, 
    string? Code,
    string? Title,
    string? Alias) : IRequest<bool>;

  public class UpdateCourseHandler(ApplicationDbContext context) 
    : IRequestHandler<UpdateCourseCommand, bool>
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<bool> Handle(UpdateCourseCommand command, CancellationToken token)
    {
      var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == command.Id, token);

      if (course is null) return false;

      course.Update(course.Code, course.Title, course.Alias);
      await _context.SaveChangesAsync(token);

      return true;
    }
  }

}