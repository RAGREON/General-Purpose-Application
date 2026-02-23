namespace GpSys.Models.DTOs
{
  public record CreateCourseDto(
    string Code, 
    string Title,
    string Alias
  );
}