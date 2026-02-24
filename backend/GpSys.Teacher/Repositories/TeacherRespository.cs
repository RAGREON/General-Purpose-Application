using GpSys.Teacher.Interfaces;

namespace GpSys.Teacher.Repositories
{
  public class TeacherRespository(TeacherContext _context) : ITeacherRepository
  {
    public async Task<TeacherEntity?> GetByIdAsync(int id)
    {
      return await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IList<TeacherEntity>> GetAllAsync()
    {
      return await _context.Teachers.ToListAsync();
    }

    public async Task<int> AddAsync(TeacherEntity teacher)
    {
      _context.Teachers.Add(teacher);
      await _context.SaveChangesAsync();
      return teacher.Id;
    }

    public async Task<TeacherEntity> UpdateAsync(TeacherEntity teacher)
    {
      _context.Update(teacher);
      await _context.SaveChangesAsync();
      return teacher;
    }

    public async Task<bool> RemoveAsync(int id)
    {
      var teacher = await GetByIdAsync(id) ?? throw new Exception("Invalid id");

      _context.Teachers.Remove(teacher);
      await _context.SaveChangesAsync();
      
      return true;
    }
  }
}