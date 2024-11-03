using MockQueryable;
using MockQueryable.Moq;
using Moq;
using RedditListener.Models;

namespace RedditListener.Tests.Models
{
    public static class MockRedditContext
    {
        public static Mock<RedditContext> CreateMockDbContext()
        {
            var posts = new List<Post>
            {
                new Post { id = "5", ups = 5, subreddit_subscribers = 999, num_crossposts = 0 },
                new Post { id = "2", ups = 2, subreddit_subscribers = 999, num_crossposts = 10 },
                new Post { id = "4", ups = 4, subreddit_subscribers = 999, num_crossposts = 0 },
                new Post { id = "1", ups = 1, subreddit_subscribers = 999, num_crossposts = 20 },
                new Post { id = "3", ups = 3, subreddit_subscribers = 999, num_crossposts = 0 },
                new Post { id = "6", ups = 6, subreddit_subscribers = 999, num_crossposts = 30 },
            };
            var mockPosts = posts.AsQueryable().BuildMock();
            var mockPostsDbSet = posts.AsQueryable().BuildMockDbSet();

            var users = new List<User>
            {
                new User { author = "1" },
                new User { author = "2" },
                new User { author = "5" },
                new User { author = "1" },
                new User { author = "3" },
                new User { author = "6" },
                new User { author = "3" },
                new User { author = "6" },
                new User { author = "9" },
                new User { author = "6" },
            };
            var mockUsers = users.AsQueryable().BuildMock();
            var mockUsersDbSet = users.AsQueryable().BuildMockDbSet();

            var mockContext = new Mock<RedditContext>();
            mockContext.Setup(c => c.Posts).Returns(mockPostsDbSet.Object);
            mockContext.Setup(c => c.Users).Returns(mockUsersDbSet.Object);

            return mockContext;
        }
    }
}
