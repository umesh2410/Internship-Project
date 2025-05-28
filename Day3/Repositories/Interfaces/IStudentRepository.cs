using Day3.Models;

namespace Day3.Repositories.Interfaces {
    public interface IStudentRepository {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> Add(Student student);
        Task<Student> Update(Student student);
        Task<bool> Delete(int id);
    }
}
