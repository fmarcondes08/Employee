using Microsoft.AspNetCore.Mvc;
using TallerCodeChallengeApi.Models;
using TallerCodeChallengeApi.Models.Interfaces.Services;

namespace TallerCodeChallengeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController(IEmployeeService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetAll()
    {
        return Ok(await service.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employee>> GetById(int id)
    {
        var entity = await service.GetByIdAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> Create([FromBody] Employee employee)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await service.CreateAsync(employee);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut]
    public async Task<ActionResult<Employee>> Update([FromBody] Employee employee)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var updated = await service.UpdateAsync(employee);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}