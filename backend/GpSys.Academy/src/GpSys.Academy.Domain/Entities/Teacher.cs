using GpSys.Academy.Domain.Common;

namespace GpSys.Academy.Domain.Entities
{
  public class Teacher : AuditableBaseEntity
  {
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;

    private Teacher() { }

    private Teacher(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
    }

    public static Result<Teacher> Create(string firstName, string lastName)
    {
      IList<Error> errors = [];

      if (string.IsNullOrWhiteSpace(firstName))
        errors.Add(new Error("EMPTY_FILED", "FirstName cannot be empty"));

      if (string.IsNullOrWhiteSpace(lastName))
        errors.Add(new Error("EMPTY_FILED", "LastName cannot be empty"));

      if (errors.Any())
        return Result<Teacher>.Failure(errors);

      var teacher = new Teacher(firstName, lastName);

      return Result<Teacher>.Success(teacher);
    }

    public Result<Teacher> Update(string firstName, string lastName)
    {
      IList<Error> errors = [];

      if (string.IsNullOrWhiteSpace(firstName))
        errors.Add(new Error("EMPTY_FILED", "FirstName cannot be empty"));

      if (string.IsNullOrWhiteSpace(lastName))
        errors.Add(new Error("EMPTY_FILED", "LastName cannot be empty"));

      if (errors.Any())
        return Result<Teacher>.Failure(errors);

      FirstName = firstName ?? FirstName;
      LastName = lastName ?? LastName;

      return Result<Teacher>.Success(this);
    }
  }
}