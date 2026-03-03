namespace GpSys.Academy.Application.Features.Teachers
{
  public record UpdateTeacherCommand(Guid Id, string FirstName, string LastName) : IRequest<Result<bool>>;

  public class UpdateTeacherHandler(IApplicationDbContext _context) : IRequestHandler<UpdateTeacherCommand, Result<bool>>
  {
    public async Task<Result<bool>> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
      var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

      if (teacher is null)
        return Result<bool>.Failure($"Invalid Id: {request.Id}");

      var result = teacher.Update(request.FirstName, request.LastName);

      if (!result.IsSuccess)
        return Result<bool>.Failure(result.Errors);
      
      return Result<bool>.Success(true);
    }
  }
}