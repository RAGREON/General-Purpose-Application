namespace GpSys.Academy.Application.Features.Teachers
{
  public record GetTeachersQuery() : IRequest<Result<IList<TeacherDto>>>;

  public class GetTeachersHandler(IApplicationDbContext context) : IRequestHandler<GetTeachersQuery, Result<IList<TeacherDto>>>
  {
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<IList<TeacherDto>>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
    {
      var teachers = await _context.Teachers
        .Select(x => new TeacherDto(x.Id, x.FirstName, x.LastName))
        .ToListAsync(cancellationToken);

      return Result<IList<TeacherDto>>.Success([]);
    }
  }
}