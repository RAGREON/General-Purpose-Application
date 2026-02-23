namespace GpSys.Models.DTOs
{
  public record CreateLabDto(
    int Number,
    string Title,
    string Course,
    string Teacher
  );
}