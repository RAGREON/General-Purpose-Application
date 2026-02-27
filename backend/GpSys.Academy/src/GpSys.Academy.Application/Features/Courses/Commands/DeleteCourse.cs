
namespace GpSys.Academy.Application.Features.Courses
{
  public record DeleteCourseCommand(Guid Id) : IRequest<bool>;

  public class DeleteCourseHandler(ApplicationDbContext context) 
    : IRequestHandler<DeleteCourseCommand, bool>
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<bool> Handle(DeleteCourseCommand command, CancellationToken token)
    {
      var course = await _context.Courses
        .FirstOrDefaultAsync(c => c.Id == command.Id, token);

      if (course is null) return false;

      DateTime now = DateTime.UtcNow;

      course.SoftDelete(now, null); 
      return true;
    }
  }
}