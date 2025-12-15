using Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly JobTrackerDBContext _dbContext;

        public CompanyController(JobTrackerDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FetchCompanyDTO>>> GetAllCompanies(int userId)
        {
            var companies = await _dbContext.Companies
                .Select(c => new FetchCompanyDTO(
                    c.CompanyName,
                    c.CompanyDescription
                    ))
                .ToListAsync();

            return Ok(companies);
        }
    }
}
