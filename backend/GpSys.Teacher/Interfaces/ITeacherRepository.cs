using GpSys.Models.Entities;

namespace GpSys.Teacher.Interfaces
{
  public interface ITeacherRepository
  {
    Task<TeacherEntity?> GetByIdAsync(int id);
    Task<IList<TeacherEntity>> GetAllAsync();
    Task<int> AddAsync(TeacherEntity teacher);
    Task<TeacherEntity> UpdateAsync(TeacherEntity teacher);
    Task<bool> RemoveAsync(int id);
  }
}