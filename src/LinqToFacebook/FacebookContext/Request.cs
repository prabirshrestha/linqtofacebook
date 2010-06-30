using System;
using System.Collections.Generic;
using LinqToFacebook.Utilities;

namespace LinqToFacebook
{
    public partial class FacebookContext
    {
        #region Synchronous Methods

        #region Get

        public string Get(string path, IDictionary<string, string> parameters)
        {
            var result = WebRequestHelpers.Get(string.Format(GraphUrl, path), parameters, Settings.CompressHttp,
                                               Settings.UserAgent);

            var ex = FacebookExceptionParser.Parse(result);

            if (ex != null)
                throw ex;

            return result;
        }

        public T Get<T>(string path, IDictionary<string, string> parameters)
        {
            var jsonResult = Get(path, parameters);
            return FacebookUtilities.DeserializeJsonObject<T>(jsonResult);
        }

        /// <summary>
        /// Tries to execute get on Facebook Graph API
        /// </summary>
        /// <param name="path">Path of the url. ex: me/events</param>
        /// <param name="parameters"></param>
        /// <param name="result">Json string result from facebook.</param>
        /// <returns>Returns true if successfully executed, otherwise false.</returns>
        public bool TryGet(string path, IDictionary<string, string> parameters, out string result)
        {
            result = WebRequestHelpers.Get(string.Format(GraphUrl, path), parameters, Settings.CompressHttp,
                                           Settings.UserAgent);

            var ex = FacebookExceptionParser.Parse(result);

            if (ex != null)
                result = string.Empty;

            return ex == null;
        }

        public bool TryGet<T>(string path, IDictionary<string, string> parameters, out T obj)
        {
            string json = WebRequestHelpers.Get(string.Format(GraphUrl, path), parameters, Settings.CompressHttp,
                                           Settings.UserAgent);

            var ex = FacebookExceptionParser.Parse(json);

            if (ex == null)
            {
                try
                {   // deserializing might coz another error. 
                    obj = FacebookUtilities.DeserializeJsonObject<T>(json);
                    return true;
                }
                catch (Exception e)
                {
                    obj = default(T);
                    return false;
                }
            }

            obj = default(T);
            return false;
        }

        #endregion

        #region Post

        public string Post(string path, IDictionary<string, string> parameters)
        {
            var result = WebRequestHelpers.Post(string.Format(GraphUrl, path), parameters, Settings.CompressHttp,
                                                Settings.UserAgent);

            var ex = FacebookExceptionParser.Parse(result);

            if (ex != null)
                throw ex;

            return result;
        }

        public T Post<T>(string path, IDictionary<string, string> parameters)
        {
            var jsonResult = Post(path, parameters);
            return FacebookUtilities.DeserializeJsonObject<T>(jsonResult);
        }

        public bool TryPost(string path, IDictionary<string, string> parameters, out string result)
        {
            result = WebRequestHelpers.Post(string.Format(GraphUrl, path), parameters, Settings.CompressHttp,
                                                Settings.UserAgent);

            var ex = FacebookExceptionParser.Parse(result);

            if (ex != null)
                result = string.Empty;

            return ex == null;
        }

        public bool TryPost<T>(string path, IDictionary<string, string> parameters, out T obj)
        {
            string json = WebRequestHelpers.Post(string.Format(GraphUrl, path), parameters, Settings.CompressHttp,
                                           Settings.UserAgent);

            var ex = FacebookExceptionParser.Parse(json);

            if (ex == null)
            {
                try
                {   // deserializing might coz another error. 
                    obj = FacebookUtilities.DeserializeJsonObject<T>(json);
                    return true;
                }
                catch (Exception e)
                {
                    obj = default(T);
                    return false;
                }
            }

            obj = default(T);
            return false;
        }

        #endregion

        #endregion

        #region Asynchronous Methods

        // todo async methods for get and post

        #endregion
    }
}