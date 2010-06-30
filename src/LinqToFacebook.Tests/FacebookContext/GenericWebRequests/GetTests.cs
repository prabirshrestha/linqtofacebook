using System.Linq;
using Xunit;

namespace LinqToFacebook.Tests.FacebookContextTests.GenericWebRequests
{
    public class GetTests
    {
        private FacebookContext _fbContext;

        public GetTests()
        {
            _fbContext = new FacebookContext(new FacebookSettings { AccessToken = Helpers.AccessToken });
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

        [Fact]
        public void Linq_GetUserById()
        {
            // Arrange
            var query = from user in _fbContext.Users
                        where user.ID == "100001241534829"
                        select user;

            // Act
            var u = query.First();

            // Assert
            Assert.Equal("Jimmi Hendrix", u.Name);
        }
    }
}