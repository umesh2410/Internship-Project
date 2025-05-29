using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services;

namespace StudentApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // POST: api/students/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var student = await _studentService.AuthenticateAsync(request.Email, request.Password);
        if (student == null)
            return Unauthorized("Invalid email or password");

        return Ok(new { student.Id, student.FirstName, student.LastName, student.Email });
    }

    // GET: api/students
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentService.GetAllAsync();
        return Ok(students);
    }

    // GET: api/students/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _studentService.GetByIdAsync(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Student student)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdStudent = await _studentService.CreateAsync(student);
        return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }, createdStudent);
    }

    // PUT: api/students/5
    [HttpPut("{id}")]
public async Task<IActionResult> Update(int id, [FromBody] Student student)
{
    if (id != student.Id)
        return BadRequest("ID mismatch");

    try
    {
        await _studentService.UpdateAsync(student);
    }
    catch (KeyNotFoundException)
    {
        return NotFound();
    }

    return NoContent();
}

    // DELETE: api/students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _studentService.GetByIdAsync(id);
        if (student == null)
            return NotFound();

        await _studentService.DeleteAsync(id);
        return NoContent();
    }
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}