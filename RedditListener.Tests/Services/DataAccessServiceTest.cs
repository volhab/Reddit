using Moq;
using RedditListener.Models;
using RedditListener.Services;
using RedditListener.Tests.Models;

namespace RedditListener.Tests.Services
{
    [TestClass]
    public class DataAccessServiceTest
    {
        Mock<RedditContext> TestRedditContext = new Mock<RedditContext>();

        [TestMethod]
        public async Task SavePosts()
        {
            // Arrange
            TestRedditContext = MockRedditContext.CreateMockDbContext();
            var service = new DataAccessService(TestRedditContext.Object);
            var posts = new List<Post>
            {
                new Post { id = "9", ups = 9, subreddit_subscribers = 999, num_crossposts = 50 }
            };

            // Act
            await service.SavePosts(posts);

            // Assert
            // This is a placeholder for future tests
        }

        [TestMethod]
        public async Task SaveUsers()
        {
            // Arrange
            TestRedditContext = MockRedditContext.CreateMockDbContext();
            var service = new DataAccessService(TestRedditContext.Object);
            var posts = new List<Post>
            {
                new Post 
                { 
                    id = "9", 
                    ups = 9, 
                    subreddit_subscribers = 999, 
                    num_crossposts = 50,
                    created_utc = 1730399295.0
                }
            };

            // Act
            await service.SaveUsers(posts);

            // Assert
            // This is a placeholder for future tests
        }
    }
}