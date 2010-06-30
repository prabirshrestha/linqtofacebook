using Xunit;
using Xunit.Extensions;

namespace LinqToFacebook.Tests.FacebookContextTests.Validations
{
    public class ValidateWriteFeedParamsDummyAccessTokenTests
    {
        private readonly FacebookContext _facebookContext;
        public ValidateWriteFeedParamsDummyAccessTokenTests()
        {
            _facebookContext = new FacebookContext(new FacebookSettings { AccessToken = "dummy_access_token" });
        }

        [Fact]
        public void RequestUrl_Tests()
        {
            // Arrange
            string requestUrl;
            string postData;

            // Act
            _facebookContext.ValidateWriteFeedParams("dummy message", null, null, null, null, null, out requestUrl,
                                                     out postData);

            // Assert
            Assert.Equal("https://graph.facebook.com/me/feed?access_token=" + _facebookContext.Settings.AccessToken,
                         requestUrl);
        }

        [Theory]
        [InlineData("message", null, null, null, null, null, "message=message")]
        [InlineData("testing new message", null, null, null, null, null, "message=testing%20new%20message")]
        [InlineData("testing new message", null, "www.google.com", null, null, null, "message=testing%20new%20message&link=www.google.com")]
        public void PostData_Tests(string message, string pictureUrl, string link, string linkName, string linkCaption, string linkDescription, string expectedPostData)
        {
            // Arrange
            string requestUrl;
            string postData;

            // Act
            _facebookContext.ValidateWriteFeedParams(message, pictureUrl, link, linkName, linkCaption, linkDescription,
                                                     out requestUrl, out postData);

            // Assert
            Assert.Equal(expectedPostData, postData);
        }
    }
}