namespace Lab.Models
{
  public class LabEntity
  {
    public int Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; } = default!;
    public string Course { get; set; } = default!;
    public string Teacher { get; set; } = default!;
  }
}