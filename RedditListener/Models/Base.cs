
namespace RedditListener.Models
{
    public class Base
    {
        public string? author_fullname { get; set; }
        public string? author { get; set; }
        public int posts_count { get; set; }
        public int num_crossposts { get; set; }
    }
}
