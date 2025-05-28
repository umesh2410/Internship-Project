using Day3.Models;
using Day3.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var student = await _repo.GetById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student) {
            var result = await _repo.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}/name")]
        public async Task<IActionResult> ChangeName(int id, string newName) {
            var existingStudent = await _repo.GetById(id);
            if (existingStudent == null) return NotFound("Student not found.");

            existingStudent.Name = newName;
            var result = await _repo.Update(existingStudent);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var deleted = await _repo.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
