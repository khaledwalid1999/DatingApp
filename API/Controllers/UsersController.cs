using API.bin;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase

    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            if (users.Count == 0)
            {
                return NotFound();
            }

            else
            { return users; }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user.Id == 0)
            {
                return NotFound();
            }

            else
            { return user; }
        }


        // [HttpPost]
        // public <IEnumerable<AppUser>> CreateUser(int Id,string UserName)
        // {

        // }
    }
}