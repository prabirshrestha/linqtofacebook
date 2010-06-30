using System;

namespace LinqToFacebook
{
    public class LinqToFacebookException : Exception
    {
        public LinqToFacebookException()
        {

        }

        public LinqToFacebookException(string message)
            : base(message)
        {

        }

        public LinqToFacebookException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}