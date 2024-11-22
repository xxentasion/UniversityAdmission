using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Data;
using UniversityAdmission.Models;
using UniversityAdmission.Models.DTO;

namespace UniversityAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(UniversityContext context) : ControllerBase
    {
        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(string id)
        {
            var student = await context.Students
                .Include(s => s.Applications)
                    .ThenInclude(a => a.Course)
                        .ThenInclude(c => c.Faculty)
                .FirstOrDefaultAsync(s => s.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.StudentID }, student);
        }

        // PUT: api/Students/STU001
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(string id, StudentRequest studentRequest)
        {
            // Найдем студента по id
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            // Обновим данные студента, основываясь на переданных данных
            student.FirstName = studentRequest.FirstName;
            student.LastName = studentRequest.LastName;
            student.BirthDate = studentRequest.BirthDate;
            student.Email = studentRequest.Email;
            student.PhoneNumber = studentRequest.PhoneNumber;
            student.Address = studentRequest.Address;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(string id)
        {
            return context.Students.Any(e => e.StudentID == id);
        }
    }
}
