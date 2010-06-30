using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LinqToFacebook
{
    public partial class FacebookContext
    {
        private static WebResponse RequestAsWebResponse(string requestUrl, string postString, bool compressHttp, bool useGet)
        { // http://facebooktoolkit.codeplex.com/SourceControl/changeset/view/51096#420763
            HttpWebRequest request;
            if (useGet)
            {
                request = (HttpWebRequest)WebRequest.Create(requestUrl + "?" + postString);
                request.Method = "GET";
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(requestUrl);
                request.MediaType = "POST";
            }
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";

            if (compressHttp)
                request.Headers.Add("Accept-Encoding", "gzip,deflate");

            if (!useGet && !string.IsNullOrEmpty(postString))
            {
                var parameterString = Encoding.UTF8.GetBytes(postString);
                request.ContentLength = parameterString.Length;

                using (var buffer = request.GetRequestStream())
                {
                    buffer.Write(parameterString, 0, parameterString.Length);
                    buffer.Close();
                }
            }

            return request.GetResponse();
        }

        public static string Request(string requestUrl, string postString, bool compressHttp, bool useGet, bool throwError)
        {
            var response = RequestAsWebResponse(requestUrl, postString, compressHttp, useGet);
            string result;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            if (throwError)
                throw new NotImplementedException("throwError is not implemented yet. please pass it as false");
            if (compressHttp)
                throw new NotImplementedException("compressHttp is not implemented yet. please pass it as false");
            return result;
        }

        public static JToken RequestAsJToken(string requestUrl, string postString, bool compressHttp, bool useGet, bool throwError)
        {
            var jsonString = Request(requestUrl, postString, compressHttp, useGet, throwError);
            return ToJToken(jsonString);
        }

        private static JToken ToJToken(string jsonString)
        {
            using (StringReader reader = new StringReader(jsonString))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(reader))
                {
                    return JToken.ReadFrom(jsonTextReader);
                }
            }
        }
    }
}