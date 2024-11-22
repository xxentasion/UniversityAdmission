using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Data;
using UniversityAdmission.Models;

namespace UniversityAdmission.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(UniversityContext context) : ControllerBase
{
    // GET: api/Courses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
        return await context.Courses.ToListAsync();
    }

    // GET: api/Courses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(string id)
    {
        var course = await context.Courses.FindAsync(id);

        if (course == null)
        {
            return NotFound();
        }

        return course;
    }

    // POST: api/Courses
    [HttpPost]
    public async Task<ActionResult<Course>> PostCourse(Course course)
    {
        context.Courses.Add(course);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetCourse", new { id = course.CourseID }, course);
    }

    // PUT: api/Courses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCourse(string id, Course course)
    {
        if (id != course.CourseID)
        {
            return BadRequest();
        }

        context.Entry(course).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CourseExists(id))
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

    // DELETE: api/Courses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(string id)
    {
        var course = await context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        context.Courses.Remove(course);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool CourseExists(string id)
    {
        return context.Courses.Any(e => e.CourseID == id);
    }
}