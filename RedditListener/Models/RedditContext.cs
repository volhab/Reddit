using Microsoft.EntityFrameworkCore;

namespace RedditListener.Models
{
    public class RedditContext: DbContext
    {
        public RedditContext(DbContextOptions<RedditContext> options)
    : base(options)
        {
        }

        public RedditContext() : base()
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("RedditDatabase");
        }
    }
}
