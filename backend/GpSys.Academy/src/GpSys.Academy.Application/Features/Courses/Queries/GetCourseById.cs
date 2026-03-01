namespace GpSys.Academy.Application.Features.Courses
{
  public record GetCourseByIdQuery(Guid Id) : IRequest<Result<CourseDto>>;

  public class GetCourseByIdHandler(IApplicationDbContext context) 
    : IRequestHandler<GetCourseByIdQuery, Result<CourseDto>>
  {
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<CourseDto>> Handle(GetCourseByIdQuery query, CancellationToken token)
    {
      var course = await _context.Courses
        .AsNoTracking()
        .Where(c => c.Id == query.Id)
        .Select(c => new CourseDto(c.Id, c.Code, c.Title, c.Alias))
        .FirstOrDefaultAsync(token);

      if (course is null) 
        return Result<CourseDto>.Failure($"Course not found.");

      return Result<CourseDto>.Success(course);
    }
  }
}