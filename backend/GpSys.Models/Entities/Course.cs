namespace GpSys.Models.Entities
{
  public class CourseEntity
  {
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Alias { get; set; } = null!;
  }
}