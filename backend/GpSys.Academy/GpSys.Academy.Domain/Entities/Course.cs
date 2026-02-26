using GpSys.Academy.Domain.Common;

namespace GpSys.Academy.Domain.Entities
{
  public class Course : AuditableBaseEntity
  {
    public string Code { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Alias { get; private set; } = null!;

    private Course() { }

    public Course(string code, string title, string alias)
    {
      Code = code;
      Title = title;
      Alias = alias;
    }
  }
}