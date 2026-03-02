namespace GpSys.Academy.Application.Features.Teachers
{
  public record DeleteTeacherCommand(Guid Id) : IRequest<Result<bool>>;

  public class DeleteTeacherHandler(IApplicationDbContext context) : IRequestHandler<DeleteTeacherCommand, Result<bool>>
  {
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<bool>> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
      var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

      if (teacher is null)
        return Result<bool>.Failure($"Invalid Id: {request.Id}");

      _context.Teachers.Remove(teacher);
      await _context.SaveChangesAsync(cancellationToken);

      return Result<bool>.Success(true);
    }
  }
}