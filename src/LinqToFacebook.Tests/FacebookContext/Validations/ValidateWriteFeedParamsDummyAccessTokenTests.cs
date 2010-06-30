using System.Collections.Generic;
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
            string path;
            IDictionary<string, string> postData;

            // Act
            _facebookContext.ValidateWriteFeedParams("dummy message", null, null, null, null, null, out path,
                                                     out postData);

            // Assert
            Assert.Equal("me/feed?access_token=" + _facebookContext.Settings.AccessToken, path);
        }

        [Theory]
        [InlineData("message", null, null, null, null, null, "message=message")]
        [InlineData("testing new message", null, null, null, null, null, "message=testing%20new%20message")]
        [InlineData("testing new message", null, "www.google.com", null, null, null, "message=testing%20new%20message&link=www.google.com")]
        // todo: more tests
        public void PostData_Tests(string message, string pictureUrl, string link, string linkName, string linkCaption, string linkDescription, string expectedPostData)
        {
            // Arrange
            string path;
            IDictionary<string, string> postData;

            // Act
            _facebookContext.ValidateWriteFeedParams(message, pictureUrl, link, linkName, linkCaption, linkDescription,
                                                     out path, out postData);

            // Assert
            Assert.Equal(expectedPostData, postData.ToPostString(true));
        }
    }
}