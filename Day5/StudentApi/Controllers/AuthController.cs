using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.DTOs;
using StudentApi.Helpers;
using StudentApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly StudentDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(StudentDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterStudentDto dto)
    {
        if (await _context.Students.AnyAsync(s => s.Email == dto.Email))
            return BadRequest("Email already exists");

        var hmacKey = Encoding.UTF8.GetBytes(_config["PasswordHashKey"] ?? throw new ArgumentNullException("PasswordHashKey", "Password hash key is not configured."));
        using var hmac = new HMACSHA256(hmacKey);
        var student = new Student
        {
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)))
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return Ok("Student registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest dto)
    {
        var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == dto.Email);
        if (student == null) return Unauthorized("Invalid email");

        var hmacKey = Encoding.UTF8.GetBytes(_config["PasswordHashKey"] ?? throw new ArgumentNullException("PasswordHashKey", "Password hash key is not configured."));
        using var hmac = new HMACSHA256(hmacKey);
        var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)));

        if (computedHash != student.PasswordHash)
            return Unauthorized("Invalid password");

        var token = JwtHelper.GenerateToken(student, _config);
        return Ok(new LoginResponse { Token = token, FullName = student.FullName, Email = student.Email });
    }
}
