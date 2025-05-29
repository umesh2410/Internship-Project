using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> AuthenticateAsync(string email, string password)
    {
        // In a real app, use proper password hashing (e.g., BCrypt)
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.Email == email && s.PasswordHash == password);
        return student;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task<Student> CreateAsync(Student student)
    {
        // In a real app, hash the password before saving
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

   public async Task UpdateAsync(Student student)
{
    var existingStudent = await _context.Students.FindAsync(student.Id);
    if (existingStudent == null)
        throw new KeyNotFoundException($"Student with Id {student.Id} not found.");

    // Map only the updatable fields from the input student
    existingStudent.FirstName = student.FirstName;
    existingStudent.LastName = student.LastName;
    existingStudent.Email = student.Email;
    existingStudent.PasswordHash = student.PasswordHash; // Or handle password update securely
    // Add other properties you want to update

    await _context.SaveChangesAsync();
}
    public async Task DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}