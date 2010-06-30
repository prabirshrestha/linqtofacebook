using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LinqToFacebook
{
    internal static class Extensions
    {
        internal static string ToPostString(this IDictionary<string, string> postData, bool urlEncode)
        {   // don't urlencode when using get.
            var sb = new StringBuilder();
            foreach (string key in postData.Keys)
            {
                if (sb.Length > 0)
                    sb.Append('&');

                sb.Append(urlEncode ? key.UrlEncode() : key);
                sb.Append('=');
                sb.Append(urlEncode ? postData[key].UrlEncode() : postData[key]);
            }
            return sb.ToString();
        }

        internal static string AttachPostDataToUri(this string uri, IDictionary<string, string> postData, bool urlEncode)
        {
            var newUri = new StringBuilder();
            newUri.Append(uri);

            if (postData != null)
                newUri.AppendFormat("?{0}", postData.ToPostString(urlEncode));

            return newUri.ToString();
        }

        internal static string UrlEncode(this string stringToEncode)
        {
            return Uri.EscapeDataString(stringToEncode);
        }

        internal static string GetFacebookID(this string jsonString)
        {
            return jsonString.ToJToken().Value<string>("id");
        }

        internal static JToken ToJToken(this string jsonString)
        {
            using (var reader = new StringReader(jsonString))
            {
                using (var jsonTextReader = new JsonTextReader(reader))
                {
                    return JToken.ReadFrom(jsonTextReader);
                }
            }
        }
    }
}
