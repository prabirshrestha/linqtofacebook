using Xunit;

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
    }
}