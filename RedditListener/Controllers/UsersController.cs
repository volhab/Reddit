
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedditListener.Models;

namespace RedditListener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RedditContext _context;

        public UsersController(RedditContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("MostPosts")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            // for simplicity will return 5 users with most posts
            var users = await _context.Users.ToListAsync();
            var result = users.GroupBy(u => u.author).Select(group => new User { author = group.Key, posts_count = group.Count() })
                .OrderByDescending(u => u.posts_count)
                .Take(5).ToList();
            return result;
        }
    }
}
