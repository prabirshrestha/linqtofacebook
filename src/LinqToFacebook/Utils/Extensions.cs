using System;
using System.Collections.Generic;
using System.Text;

namespace LinqToFacebook
{
    internal static class Extensions
    {
        internal static string ToPostString(this IDictionary<string, string> postData)
        {
            var sb = new StringBuilder();
            foreach (string key in postData.Keys)
            {
                if (sb.Length > 0)
                    sb.Append('&');

                sb.Append(key.UrlEncode());
                sb.Append('=');
                sb.Append(postData[key].UrlEncode());
            }
            return sb.ToString();
        }

        internal static string UrlEncode(this string stringToEncode)
        {
            return Uri.EscapeDataString(stringToEncode);
        }
    }
}
