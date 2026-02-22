
using Lab.Services;

namespace Lab.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LabController : ControllerBase
  {
    private readonly LabService _service;

    public LabController(LabService service)
    {
      _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var lab = await _service.GetByIdAsync(id);
      return Ok(lab);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetLabAll()
    {
      var result = await _service.GetAllAsync();
      return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLab([FromBody] CreateLabDto dto)
    {
      int id = await _service.CreateAsync(dto);
      return CreatedAtAction(nameof(GetById), new { id = id }, dto);
    }
  }
}