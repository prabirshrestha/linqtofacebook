using System.Collections.Generic;

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

            return ex == null;
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

        public bool TryPost(string path, IDictionary<string, string> parameters, out string result)
        {
            result = WebRequestHelpers.Post(string.Format(GraphUrl, path), parameters, Settings.CompressHttp,
                                                Settings.UserAgent);

            var ex = FacebookExceptionParser.Parse(result);

            return ex == null;
        }

        #endregion
        
        #endregion

        #region Asynchronous Methods

        // todo async methods for get and post

        #endregion
    }
}