using GpSys.Academy.Domain.Common;

namespace GpSys.Academy.Domain.Entities
{
  public class Course : AuditableBaseEntity
  {
    public string Code { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Alias { get; private set; } = null!;

    private Course() { }

    private Course(string code, string title, string alias)
    {
      Code = code;
      Title = title;
      Alias = alias;
    }

    public static Result<Course> Create(string code, string title, string alias)
    {
      IList<Error> errors = [];

      if (string.IsNullOrWhiteSpace(code))
        errors.Add(new Error("EMPTY_FIELD", "Course code is required."));
      
      if (string.IsNullOrWhiteSpace(title))
        errors.Add(new Error("EMPTY_FIELD", "Course title is required"));

      if (errors.Any()) 
        return Result<Course>.Failure(errors);

      var course = new Course(code, title, alias);

      return Result<Course>.Success(course);
    }

    public Result<Course> Update(string? code, string? title, string? alias)
    {
      IList<Error> errors = [];

      if (code is { Length: 0 } || (code != null && string.IsNullOrWhiteSpace(code)))
        errors.Add(new Error("EMPTY_FIELD", "Course Code cannot be cleared"));

      if (title is { Length: 0 } || (title != null && string.IsNullOrWhiteSpace(title)))
        errors.Add(new Error("EMPTY_FIELD", "Course title cannot be cleared.")); 

      if (errors.Any()) 
        return Result<Course>.Failure(errors);

      if (!string.IsNullOrWhiteSpace(code)) Code = code; 
      if (!string.IsNullOrWhiteSpace(title)) Title = title; 
      if (!string.IsNullOrWhiteSpace(alias)) Alias = alias; 

      return Result<Course>.Success(this);
    }
  }
}