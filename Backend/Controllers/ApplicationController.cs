using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly JobTrackerDBContext _dbContext;

        public ApplicationController(JobTrackerDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FetchApplicationDTO>> GetApplicationById(int id)
        {
            var application = await _dbContext.Applications
                .Where(a => a.Id == id)
                .Select(a => new FetchApplicationDTO(
                    a.UserId,
                    a.CompanyId,
                    a.JobTitle,
                    a.JobDescription,
                    a.Status,
                    a.Salary
                    ))
                .SingleOrDefaultAsync();

            if (application == null)
                return NotFound();

            return Ok(application);
        }

        [HttpGet("user/{userId:int}")]
        public async Task<ActionResult<IEnumerable<FetchApplicationDTO>>> GetAllApplicationsByUserId(int userId)
        {
            var applications = await _dbContext.Applications
                .Where(a => a.UserId == userId)
                .Select(a => new FetchApplicationDTO(
                    a.UserId,
                    a.CompanyId,
                    a.JobTitle,
                    a.JobDescription,
                    a.Status,
                    a.Salary
                    ))
                .ToListAsync();

            return Ok(applications);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewJobApplication()
        {
            return BadRequest();
        }
    }
}
