using System;

namespace LinqToFacebook
{
    public class FacebookApiException : LinqToFacebookException
    {
        private readonly string _errorCode;

        public FacebookApiException()
            : this(null, "Unknown Facebook Api Exception Occured", null)
        {

        }

        public FacebookApiException(string message)
            : this(null, message, null)
        {

        }

        public FacebookApiException(string errorCode, string message)
            : this(errorCode, message, null)
        {

        }

        public FacebookApiException(string errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            _errorCode = errorCode;
        }

        public string ErrorCode
        {
            get { return _errorCode; }
        }
    }
}