namespace GpSys.Course.Interfaces
{
  public interface ICourseRepository
  {
    Task<CourseEntity?> GetByIdAsync(int id);
    Task<IList<CourseEntity>> GetAllAsync();
    Task<int> AddAsync(CourseEntity course);
    Task<CourseEntity> UpdateAsync(CourseEntity course);
  }  
}