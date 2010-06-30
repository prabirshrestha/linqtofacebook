using System;
using Xunit;

namespace LinqToFacebook.Tests.FacebookContextTests.Validations
{
    public class ValidateWriteFeedParamsTests
    {
        private FacebookContext _facebookContext;
        public ValidateWriteFeedParamsTests()
        {
            _facebookContext = new FacebookContext(new FacebookSettings());
        }

        [Fact]
        public void ValidateWriteFeedParams_Throws_ArgumentNullException_When_message_is_null()
        {
            // Arrange
            string requestUrl;
            string postData;

            // Act/Arrage
            Assert.Throws<ArgumentNullException>(
                () =>
                _facebookContext.ValidateWriteFeedParams(null, null, null, null, null, null, out requestUrl,
                                                         out postData));
        }
    }
}