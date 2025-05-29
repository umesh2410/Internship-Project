using StudentApi.Models;

namespace StudentApi.Services;

public interface IStudentService
{
    Task<Student?> AuthenticateAsync(string email, string password);
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task<Student> CreateAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(int id);
}