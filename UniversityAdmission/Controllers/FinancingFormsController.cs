using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Data;
using UniversityAdmission.Models;

namespace UniversityAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancingFormsController(UniversityContext context) : ControllerBase
    {
        // GET: api/FinancingForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancingForm>>> GetFinancingForms()
        {
            return await context.FinancingForms.ToListAsync();
        }
    }
}