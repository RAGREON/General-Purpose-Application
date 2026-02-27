namespace GpSys.Academy.Application.Features.Courses
{
  public record CreateCourseCommand(string Code, string Title, string Alias) : IRequest<Guid>;

  public class CreateCourseHandler(ApplicationDbContext _context) 
    : IRequestHandler<CreateCourseCommand, Guid>
  {
    public async Task<Guid> Handle(CreateCourseCommand command, CancellationToken token)
    {
      var course = new Course(command.Code, command.Title, command.Alias);
      _context.Courses.Add(course);
      await _context.SaveChangesAsync(token);
      return course.Id;
    }
  }
}