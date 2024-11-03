using RedditListener.Interfaces;
using RedditListener.Models;

namespace RedditListener.Services
{
    public class DataAccessService: IDataAccessService
    {
        private readonly RedditContext _context;

        public DataAccessService(RedditContext context)
        {
            _context = context;
        }

        public async Task SavePosts(List<Post> posts)
        {
            try
            {
                await _context.Posts.AddRangeAsync(posts);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task SaveUsers(List<Post> posts)
        {
            try
            {
                var users = new List<User>();
                foreach (var post in posts)
                {
                    users.Add(new User
                    {
                        created_utc = post.created_utc.ToString(),
                        author = post.author,
                        author_fullname = post.author_fullname,
                        num_crossposts = post.num_crossposts
                    });
                }
                _context.Users.AddRange(users);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
