namespace GpSys.Academy.Application.Features.Courses
{
  public record GetCoursesQuery() : IRequest<IList<CourseDto>>;

  public class GetCoursesHandler(ApplicationDbContext context) 
    : IRequestHandler<GetCoursesQuery, IList<CourseDto>>
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<IList<CourseDto>> Handle(GetCoursesQuery command, CancellationToken token)
    {
      var courses = await _context.Courses
        .Select(c => new CourseDto(
          c.Id, c.Code, c.Title, c.Alias))
        .ToListAsync(token);

      return courses;
    }
  }
}