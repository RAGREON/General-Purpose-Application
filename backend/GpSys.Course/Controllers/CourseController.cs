using GpSys.Course.Services;

namespace GpSys.Course.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CourseController(CourseService _service) : ControllerBase
  {
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseByIdAsync([FromRoute] int id)
    {
      var course = await _service.GetCourseByIdAsync(id);
      return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourseAsync([FromBody] CreateCourseDto dto)
    {
      int id = await _service.CreateCourseAsync(dto);
      return CreatedAtAction(nameof(GetCourseByIdAsync), new { id }, new { id });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCourseAsync([FromRoute] int id, [FromBody] UpdateCourseDto dto)
    {
      var updatedCourse = await _service.UpdateCourseAsync(id, dto);
      return Ok(updatedCourse);
    }
  }
}