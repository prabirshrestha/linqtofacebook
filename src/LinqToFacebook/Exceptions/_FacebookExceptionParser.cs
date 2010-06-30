using System;
using Newtonsoft.Json.Linq;

namespace LinqToFacebook
{
    public class FacebookExceptionParser
    {
        public static LinqToFacebookException Parse(string jsonString)
        {
            return Parse(jsonString.ToJToken());
        }

        public static LinqToFacebookException Parse(JToken jToken)
        {
            if (jToken == null)
                throw new ArgumentNullException("jToken");

            var errorMessage = jToken["error"];

            return errorMessage != null ? ParseErrorMessage(jToken.Value<string>(errorMessage)) : null;
        }

        private static LinqToFacebookException ParseErrorMessage(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
                return null;

            return new LinqToFacebookException(errorMessage);
        }
    }
}