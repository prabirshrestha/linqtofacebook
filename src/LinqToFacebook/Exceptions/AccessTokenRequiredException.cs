using System;

namespace LinqToFacebook
{
    public class AccessTokenRequiredException : LinqToFacebookException
    {
        public AccessTokenRequiredException()
            : this((Exception)null)
        {

        }

        public AccessTokenRequiredException(string message)
            : base(message)
        {

        }

        public AccessTokenRequiredException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public AccessTokenRequiredException(Exception innerException)
            : base("AccessToken must be specified in FacebookContext.Settings.AccessToken for this method to be invoked.", innerException)
        {

        }
    }
}