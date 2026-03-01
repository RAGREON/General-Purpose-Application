namespace GpSys.Academy.Application.Features.Courses
{
  public record GetCoursesQuery() : IRequest<Result<IList<CourseDto>>>;

  public class GetCoursesHandler(IApplicationDbContext context) 
    : IRequestHandler<GetCoursesQuery, Result<IList<CourseDto>>>
  {
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<IList<CourseDto>>> Handle(GetCoursesQuery command, CancellationToken token)
    {
      var courses = await _context.Courses
        .Select(c => new CourseDto(
          c.Id, c.Code, c.Title, c.Alias))
        .ToListAsync(token);

      return Result<IList<CourseDto>>.Success(courses);
    }
  }
}