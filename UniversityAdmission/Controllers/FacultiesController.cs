using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Data;
using UniversityAdmission.Models;
using UniversityAdmission.Models.DTO;

namespace UniversityAdmission.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacultiesController(UniversityContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Faculty>>> GetFaculties()
    {
        return await context.Faculties.Include(f => f.Courses).ToListAsync();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Faculty>> GetFaculty(Guid id)
    {
        var faculty = await context.Faculties
            .Include(a => a.Courses)
            .FirstOrDefaultAsync(a => a.FacultyID == id);
        if (faculty == null)
        {
            return NotFound();
        }
        return faculty;
    }

    [HttpPost]
    public async Task<ActionResult<Faculty>> PostFaculty(FacultyRequest facultyRequest)
    {
        var faculty = new Faculty
        {
            FacultyName = facultyRequest.FacultyName,
            Description = facultyRequest.Description,
        };
        
        context.Faculties.Add(faculty);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetFaculty), new { id = faculty.FacultyID }, faculty);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutFaculty(Guid id, Faculty faculty)
    {
        if (id != faculty.FacultyID)
        {
            return BadRequest();
        }

        context.Entry(faculty).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFaculty(Guid id)
    {
        var faculty = await context.Faculties.FindAsync(id);
        if (faculty == null)
        {
            return NotFound();
        }

        context.Faculties.Remove(faculty);
        await context.SaveChangesAsync();
        return NoContent();
    }
}