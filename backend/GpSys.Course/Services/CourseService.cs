namespace GpSys.Course.Services
{
  public class CourseService(ICourseRepository _repository)
  {
    private static CourseDto ProjectDto(CourseEntity course)
    {
      return new CourseDto
      (
        course.Id,
        course.Code,
        course.Title,
        course.Alias
      );
    }

    public async Task<int> CreateCourseAsync(CreateCourseDto dto)
    {
      var course = new CourseEntity
      {
        Code = dto.Code,
        Title = dto.Title,
        Alias = dto.Alias
      };

      return await _repository.AddAsync(course);
    }

    public async Task<CourseDto?> GetCourseByIdAsync(int id)
    {
      var course = await _repository.GetByIdAsync(id);
      
      if (course == null)
        return null;
      
      return ProjectDto(course);
    }

    public async Task<CourseDto> UpdateCourseAsync(int id, UpdateCourseDto dto)
    {
      var course = await _repository.GetByIdAsync(id) ?? throw new Exception("Course not found");

      course.Code = dto.Code ?? course.Code; 
      course.Title = dto.Title ?? course.Title;
      course.Alias = dto.Alias ?? course.Alias;

      await _repository.UpdateAsync(course);

      return ProjectDto(course);
    }
  }  
}