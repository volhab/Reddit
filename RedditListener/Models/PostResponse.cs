using System.Net;

namespace RedditListener.Models
{
    public class PostResponse
    {
        public HttpStatusCode responseCode { get; set; }
        public int ratelimitUsed { get; set;}
        public double ratelimitRemaining { get; set; }
        public int ratelimitReset { get; set; }
        public Data data { get; set; }
    }
}
