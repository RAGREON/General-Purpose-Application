using GpSys.Models.Entities;

namespace GpSys.Teacher.Interfaces
{
  public interface ITeacherRepository
  {
    Task<TeacherEntity?> GetByIdAsync();
    Task<IList<TeacherEntity>> GetAllAsync();
    Task<int> AddAsync();
    Task<TeacherEntity> UpdateAsync();
    Task<bool> RemoveAsync();
  }
}