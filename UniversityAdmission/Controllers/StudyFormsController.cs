using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Data;
using UniversityAdmission.Models;

namespace UniversityAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyFormsController(UniversityContext context) : ControllerBase
    {
        // GET: api/StudyForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyForm>>> GetStudyForms()
        {
            return await context.StudyForms.ToListAsync();
        }
    }
}