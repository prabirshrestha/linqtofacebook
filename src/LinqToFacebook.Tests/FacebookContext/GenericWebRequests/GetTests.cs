using Xunit;
using LinqToFacebook.Utilities;

namespace LinqToFacebook.Tests.FacebookContextTests.GenericWebRequests
{
    public class GetTests
    {
        private FacebookContext _fbContext;

        public GetTests()
        {
            _fbContext = new FacebookContext();
        }

        [Fact]
        public void Get_UserInfo_By_Username_Tests()
        {
            // Arranged in ctor

            // Act: http_get : https://graph.facebook.com/prabirshrestha
            var response = _fbContext.Get("prabirshrestha", null);

            // Assert
            var firstName = response.ToJToken().Value<string>("first_name");
            Assert.Equal("Prabir", firstName);
        }
    }
}