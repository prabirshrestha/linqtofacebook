using System;
using System.Collections.Generic;
using Xunit;

namespace LinqToFacebook.Tests.FacebookContextTests.Validations
{
    public class ValidateWriteFeedParamsNoAccessTokenTests
    {
        private readonly FacebookContext _facebookContext;
        public ValidateWriteFeedParamsNoAccessTokenTests()
        {
            _facebookContext = new FacebookContext(new FacebookSettings());
        }

        [Fact]
        public void ValidateWriteFeedParamsThrowsArgumentNullExceptionWhenMessageIsNull()
        {
            // Arrange
            string path;
            IDictionary<string, string> postData;

            // Act/Arrage
            Assert.Throws<ArgumentNullException>(
                () =>
                _facebookContext.ValidateWriteFeedParams(null, null, null, null, null, null, out path,
                                                         out postData));
        }

        [Fact]
        public void ValidateWriteFeedParamsThrowsAccessTokenRequiredExceptionWhenAccesstoeknIsNotPresent()
        {
            // Arrange
            string path;
            IDictionary<string, string> postData;

            // Act/Arrage
            Assert.Throws<AccessTokenRequiredException>(
                () =>
                _facebookContext.ValidateWriteFeedParams("dummy message", null, null, null, null, null, out path,
                                                         out postData));
        }

        [Fact]
        public void LinkIsNotSpecified_But_LinkNameIsSpecified()
        {
            // Arrange
            string path;
            IDictionary<string, string> postData;

            // Act/Arrage
            Assert.Throws<ArgumentException>(
                () =>
                _facebookContext.ValidateWriteFeedParams("dummy message", null, null, "dummy link name", null, null,
                                                         out path, out postData));
        }

        [Fact]
        public void LinkIsNotSpecified_But_LinkCaptionIsSpecified()
        {
            // Arrange
            string path;
            IDictionary<string, string> postData;

            // Act/Arrage
            Assert.Throws<ArgumentException>(
                () =>
                _facebookContext.ValidateWriteFeedParams("dummy message", null, null, null, "dummy link caption", null,
                                                         out path, out postData));
        }

        [Fact]
        public void LinkIsNotSpecified_But_LinkDescriptionIsSpecified()
        {
            // Arrange
            string path;
            IDictionary<string, string> postData;

            // Act/Arrage
            Assert.Throws<ArgumentException>(
                () =>
                _facebookContext.ValidateWriteFeedParams("dummy message", null, null, null, null,
                                                         "dummy link description", out path, out postData));
        }
    }
}