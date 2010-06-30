using System;
using System.Runtime.Serialization;
using LinqToFacebook.Utilities;

namespace LinqToFacebook
{
    public class FacebookExceptionParser
    {
        public static LinqToFacebookException Parse(string jsonString)
        {
            if (string.Compare("{\"error\"", 0, jsonString, 0, 8, StringComparison.OrdinalIgnoreCase) == 0)
            {   // if contains error_code then it has error else no
                var errorMessage = jsonString.ToJToken()["error"].ToString();
                var errObj = FacebookUtilities.DeserializeJsonObject<FacebookApiExceptionSchema>(errorMessage);
                throw new FacebookApiException(errObj.error_code, errObj.message);
            }
            return null;
        }

        internal class FacebookApiExceptionSchema
        {
            public string type { get; set; }
            public int error_code { get; set; }
            public string message { get; set; }
        }
    }
}