using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JobTrackerDBContext _dbContext;

        public UsersController(JobTrackerDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FetchUserDTO>> GetUserById(int id) {
            var user = await _dbContext.Users
                .Where(u => u.Id == id)
                .Select(u => new FetchUserDTO(
                    u.UserName,
                    u.UserEmail
                 )).FirstOrDefaultAsync();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewUser(CreateUserDTO dto)
        {

            var user = new User {
                UserName = dto.UserName,
                UserEmail = dto.UserEmail,
            };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var fetchUserDto = new FetchUserDTO(user.UserName, user.UserEmail);

            return CreatedAtAction(nameof(GetUserById), new {id = user.Id }, fetchUserDto);
        }
    } 
}

