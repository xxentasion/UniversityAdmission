using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Data;
using UniversityAdmission.Models;
using UniversityAdmission.Models.DTO;

namespace UniversityAdmission.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController(UniversityContext context) : ControllerBase
{
    // GET: api/Applications
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
    {
        return await context.Applications
            .Include(a => a.Student)    // Подгружаем связанные данные
            .Include(a => a.Course)
            .Include(a => a.Course.Faculty)
            .ToListAsync();
    }

    // GET: api/Applications/5
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Application>> GetApplication(Guid id)
    {
        var application = await context.Applications
            .Include(a => a.Student)
            .Include(a => a.Course)
            .FirstOrDefaultAsync(a => a.ApplicationID == id);

        if (application == null)
        {
            return NotFound();
        }

        return application;
    }

    // POST: api/Applications
    [HttpPost]
    public async Task<ActionResult<Application>> PostApplication(ApplicationRequest applicationRequest)
    {
        // Преобразуем ApplicationRequest в Application
        var application = new Application
        {
            StudentID = applicationRequest.StudentID,
            CourseID = applicationRequest.CourseID,
            StudyFormID = applicationRequest.StudyFormID,
            FinancingFormID = applicationRequest.FinancingFormID,
            PriorityOrder = applicationRequest.PriorityOrder,
            ApplicationDate = applicationRequest.ApplicationDate,
            Status = applicationRequest.Status
        };

        context.Applications.Add(application);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetApplication", new { id = application.ApplicationID }, application);
    }

    // PUT: api/Applications/5
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutApplication(Guid id, ApplicationRequest applicationRequest)
    {
        var application = await context.Applications.FindAsync(id);
        if (application == null)
        {
            return NotFound();
        }

        application.PriorityOrder = applicationRequest.PriorityOrder;
        application.ApplicationDate = applicationRequest.ApplicationDate;
        application.Status = applicationRequest.Status;
        application.CourseID = applicationRequest.CourseID;
        application.StudyFormID = applicationRequest.StudyFormID;
        application.FinancingFormID = applicationRequest.FinancingFormID;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ApplicationExists(id))
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

    // DELETE: api/Applications/5
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteApplication(Guid id)
    {
        var application = await context.Applications.FindAsync(id);
        if (application == null)
        {
            return NotFound();
        }

        context.Applications.Remove(application);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApplicationExists(Guid id)
    {
        return context.Applications.Any(e => e.ApplicationID == id);
    }
}