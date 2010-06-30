using Xunit;

namespace LinqToFacebook.Tests.GenericWebRequests
{
#if EXECUTE_POSTS

    public class WriteFeedTests
    {
        private FacebookContext _fbContext;

        public WriteFeedTests()
        {
            _fbContext = new FacebookContext(new FacebookSettings { AccessToken = Helpers.AccessToken });
        }

        [Fact]
        public void WriteToWall()
        {
            // Arrange
            const string message = "Test message from LinqToFacebook app";

            // Act
            string id = _fbContext.WriteFeed(message, null, null, null, null, null);
            var post = _fbContext.Get<FacebookPost>(id, null);

            // Assert
            Assert.Equal(message, post.Message);
        }
    }

#endif
}
