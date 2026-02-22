namespace Lab.Services
{
  public class LabService(ILabRepository _repository)
  {
    public async Task<LabEntity?> GetByIdAsync(int id)
    {
      return await _repository.GetByIdAsync(id);
    }

    public async Task<IList<LabEntity>> GetAllAsync() {
      return await _repository.GetAllAsync(); 
    }

    public async Task<int> CreateAsync(CreateLabDto dto) {
      var lab = new LabEntity
      {
        Number = dto.Number,
        Title = dto.Title,
        Course = dto.Course,
        Teacher = dto.Teacher
      };

      await _repository.CreateAsync(lab);
      return lab.Id;
    }

    public async Task FilterAsync() {
      await _repository.FilterAsync();
    }
  } 
}