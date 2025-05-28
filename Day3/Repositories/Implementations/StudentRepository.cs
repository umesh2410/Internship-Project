using Day3.Data;
using Day3.Models;
using Day3.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day3.Repositories.Implementations {
    public class StudentRepository : IStudentRepository {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Student>> GetAll() => await _context.Students.ToListAsync();
        public async Task<Student> GetById(int id) => await _context.Students.FindAsync(id);
        public async Task<Student> Add(Student student) {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> Update(Student student) {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<bool> Delete(int id) {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
