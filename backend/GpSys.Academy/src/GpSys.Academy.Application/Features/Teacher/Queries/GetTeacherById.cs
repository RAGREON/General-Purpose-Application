namespace GpSys.Academy.Application.Features.Teachers
{
  public record GetTeacherQuery(Guid Id) : IRequest<Result<TeacherDto>>;

  public class GetTeacherHandler(IApplicationDbContext context) : IRequestHandler<GetTeacherQuery, Result<TeacherDto>>
  {
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<TeacherDto>> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
    {
      var teacher = await _context.Teachers
        .Select(x => new TeacherDto(x.Id, x.FirstName, x.LastName))
        .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

      if (teacher is null) 
        return Result<TeacherDto>.Failure($"Invalid Id: {request.Id}");

      return Result<TeacherDto>.Success(teacher);
    }
  }
}