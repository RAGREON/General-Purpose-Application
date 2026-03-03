namespace GpSys.Academy.Application.Features.Teachers
{
  public record CreateTeacherCommand(string FirstName, string LastName) : IRequest<Result<Guid>>;

  public class CreateTeacherHandler(IApplicationDbContext context)
    : IRequestHandler<CreateTeacherCommand, Result<Guid>>
  {
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<Guid>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
      var result = Teacher.Create(request.FirstName, request.LastName);

      if (!result.IsSuccess)
        return Result<Guid>.Failure(result.Errors);

      _context.Teachers.Add(result.Value!);
      await _context.SaveChangesAsync(cancellationToken);

      return Result<Guid>.Success(result.Value!.Id);
    }
  }
}