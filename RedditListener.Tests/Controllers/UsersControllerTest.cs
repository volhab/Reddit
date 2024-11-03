using Moq;
using RedditListener.Controllers;
using RedditListener.Models;
using RedditListener.Tests.Models;

namespace RedditListener.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        Mock<RedditContext> TestRedditContext = new Mock<RedditContext>();

        [TestMethod]
        public async Task GetUsers_ReturnsFiveWithMostPosts()
        {
            // Arrange
            TestRedditContext = MockRedditContext.CreateMockDbContext();

            var controller = new UsersController(TestRedditContext.Object);

            // Act
            var result = await controller.GetUsers();

            // Assert
            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(3, result.First().posts_count);
        }
    }
}