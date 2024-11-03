using System.ComponentModel.DataAnnotations;

namespace RedditListener.Models
{
    public class User: Base
    {
        [Key]
        public string created_utc { get; set; }
    }
}
