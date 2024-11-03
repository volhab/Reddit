using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedditListener.Models;

namespace RedditListener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly RedditContext _context;

        public PostsController(RedditContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("MostUpVotes")]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            // for simplicity will return 5 posts with most up votes 
            return await _context.Posts.OrderByDescending(p => p.ups).Take(5).ToListAsync();
        }

        [HttpGet]
        [Route("MostCrossPosts")]
        public async Task<IEnumerable<Post>> GetCrossPosts()
        {
            return await _context.Posts.OrderByDescending(p => p.num_crossposts).Take(5).ToListAsync();
        }

        [HttpGet]
        [Route("Subscribers")]
        public ulong GetSubscribers()
        {
            return _context.Posts.First().subreddit_subscribers;
        }
    }
}
