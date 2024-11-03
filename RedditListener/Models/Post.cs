using System.Net;

namespace RedditListener.Models
{
    public class Data
    {
        public string after { get; set; }
        public string before { get; set; }
        public int dist { get; set; }
        public List<Child> children { get; set; }
    }

    public class Child
    {
        public Post data { get; set; }
    }

    public class Post : Base
    {
        public string id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int ups { get; set; }
        public int downs { get; set; }
        public ulong subreddit_subscribers { get; set; }
        public double created_utc { get; set; }
    }
}
