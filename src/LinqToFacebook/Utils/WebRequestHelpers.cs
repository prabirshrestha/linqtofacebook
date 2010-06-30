using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace LinqToFacebook
{
    internal static class WebRequestHelpers
    {
        #region Get methods

        internal static string Get(string uri, bool compressHttp, string userAgent)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";

            if (!string.IsNullOrEmpty(userAgent))
                request.UserAgent = userAgent;

            if (compressHttp)
            {
                request.Headers.Add("Accept-Encoding", "gzip,deflate");
                throw new LinqToFacebookException("compressHttp not supported yet. Please disable it.");
            }

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        internal static string Get(string uri, IDictionary<string, string> parameters, bool compressHttp, string userAgent)
        {
            return Get(uri.AttachPostDataToUri(parameters, false), compressHttp, userAgent);
        }

        #endregion

        #region Post methods

        internal static string Post(string uri, string postContent, bool compressHttp, string userAgent)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";

            byte[] data = Encoding.UTF8.GetBytes(postContent);
            request.ContentLength = data.Length;

            if (!string.IsNullOrEmpty(userAgent))
                request.UserAgent = userAgent;

            if (compressHttp)
            {
                request.Headers.Add("Accept-Encoding", "gzip,deflate");
                throw new LinqToFacebookException("compressHttp not supported yet. Please disable it.");
            }

            request.ContentType = "application/x-www-form-urlencoded";
            request.GetRequestStream().Write(data, 0, data.Length);

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        internal static string Post(string uri, IDictionary<string, string> parmeters, bool compressHttp, string userAgent)
        {
            return Post(uri, parmeters.ToPostString(true), compressHttp, userAgent);
        }

        #endregion

    }
}