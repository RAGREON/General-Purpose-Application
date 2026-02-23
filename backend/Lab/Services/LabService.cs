namespace Lab.Services
{
  public class LabService(ILabRepository _repository)
  {
    private static LabDto ProjectDto(LabEntity lab) {
      return new LabDto
      {
        Id = lab.Id,
        Number = lab.Number,
        Title = lab.Title,
        Course = lab.Course,
        Teacher = lab.Teacher,
        Status = lab.Status
      };
    }

    public async Task<LabDto?> GetByIdAsync(int id)
    {
      var lab = await _repository.GetByIdAsync(id);

      if (lab == null)
        return null;

      return ProjectDto(lab);
    }

    public async Task<IList<LabDto>> GetAllAsync() {
      var labs = await _repository.GetAllAsync();
      
      return [.. labs.Select(ProjectDto)];
    }

    public async Task<int> CreateAsync(CreateLabDto dto) {
      var lab = new LabEntity
      {
        Number = dto.Number,
        Title = dto.Title,
        Course = dto.Course,
        Teacher = dto.Teacher
      };

      await _repository.AddAsync(lab);
      return lab.Id;
    }

    public async Task FilterAsync() {
      await _repository.FilterAsync();
    }
  } 
}