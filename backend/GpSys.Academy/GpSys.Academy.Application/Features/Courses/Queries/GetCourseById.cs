namespace GpSys.Academy.Application.Features.Courses
{
  public record GetCourseByIdQuery(Guid Id) : IRequest<CourseDto?>;

  public class GetCourseByIdHandler(ApplicationDbContext context) 
    : IRequestHandler<GetCourseByIdQuery, CourseDto?>
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<CourseDto?> Handle(GetCourseByIdQuery query, CancellationToken token)
    {
      return await _context.Courses
        .AsNoTracking()
        .Where(c => c.Id == query.Id)
        .Select(c => new CourseDto(c.Id, c.Code, c.Title, c.Alias))
        .FirstOrDefaultAsync(token);
    }
  }
}