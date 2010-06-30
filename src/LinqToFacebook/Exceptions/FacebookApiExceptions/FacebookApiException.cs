using System;

namespace LinqToFacebook
{
    public class FacebookApiException : LinqToFacebookException
    {
        private readonly int _errorCode;

        public FacebookApiException()
            : this(0, "Unknown Facebook Api Exception Occured", null)
        {

        }

        public FacebookApiException(string message)
            : this(0, message, null)
        {

        }

        public FacebookApiException(int errorCode, string message)
            : this(errorCode, message, null)
        {

        }

        public FacebookApiException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            _errorCode = errorCode;
        }

        public int ErrorCode
        {
            get { return _errorCode; }
        }
    }
}