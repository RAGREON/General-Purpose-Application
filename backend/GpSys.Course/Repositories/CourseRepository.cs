using GpSys.Course.Data;
using GpSys.Course.Interfaces;

namespace GpSys.Course.Repositories
{
  public class CourseRepository(CourseContext _context) : ICourseRepository
  {
    public async Task<CourseEntity?> GetByIdAsync(int id)
    {
      return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IList<CourseEntity>> GetAllAsync()
    {
      return await _context.Courses.ToListAsync();
    }

    public async Task<int> AddAsync(CourseEntity course)
    {
      await _context.Courses.AddAsync(course);
      await _context.SaveChangesAsync();

      return course.Id;
    }

    public async Task<CourseEntity> UpdateAsync(CourseEntity course)
    {
      _context.Courses.Update(course);
      await _context.SaveChangesAsync();
      return course;
    }
  }
}