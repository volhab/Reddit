using Moq;
using RedditListener.Controllers;
using RedditListener.Models;
using RedditListener.Tests.Models;

namespace RedditListener.Tests.Controllers
{
    [TestClass]
    public class PostControllerTest
    {
        Mock<RedditContext> TestRedditContext = new Mock<RedditContext>();

        [TestMethod]
        public async Task GetPosts_ReturnsFiveWithMostUps()
        {
            // Arrange
            TestRedditContext = MockRedditContext.CreateMockDbContext();

            var controller = new PostsController(TestRedditContext.Object);

            // Act
            var result = await controller.GetPosts();

            // Assert
            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(6, result.First().ups);
        }

        [TestMethod]
        public void GetSubscribers_ReturnsNumberOfSubscribers()
        {
            // Arrange
            TestRedditContext = MockRedditContext.CreateMockDbContext();

            var controller = new PostsController(TestRedditContext.Object);

            // Act
            var result = controller.GetSubscribers();

            // Assert
            Assert.AreEqual(999ul, result);
        }

        [TestMethod]
        public async Task GetCrossPosts_ReturnsFiveWithMostUps()
        {
            // Arrange
            TestRedditContext = MockRedditContext.CreateMockDbContext();

            var controller = new PostsController(TestRedditContext.Object);

            // Act
            var result = await controller.GetCrossPosts();

            // Assert
            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(30, result.First().num_crossposts);
        }
    }
}