using System;
using System.Collections.Generic;

namespace LinqToFacebook
{
    public partial class FacebookContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="link"></param>
        /// <param name="linkName"></param>
        /// <param name="linkCaption"></param>
        /// <param name="linkDescription"></param>
        /// <param name="pictureUrl"></param>
        /// <returns></returns>
        public string WriteFeed(string message, string pictureUrl, string link, string linkName, string linkCaption, string linkDescription)
        {
            string requestUrl, postData;
            ValidateWriteFeedParams(message, pictureUrl, link, linkName, linkCaption, linkDescription, out requestUrl,
                                    out postData);
            return null;
        }

        /// <summary>
        /// Helpers function to Validate parameters before writing the feed
        /// </summary>
        /// <remarks>
        /// This method was created seperately in order to have unit testing without hitting the fb site.
        /// </remarks>
        internal void ValidateWriteFeedParams(string message, string pictureUrl, string link, string linkName, string linkCaption, string linkDescription,
            out string requestUrl, out string postData)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");

            AssertRequiresAccessToken();

            requestUrl = string.Format("{0}{1}?access_token={2}", GraphUrl, "/me/feed", Settings.AccessToken);
            var postDataParams = new Dictionary<string, string> { { "message", message } };

            if (!string.IsNullOrEmpty(pictureUrl))
                postDataParams.Add("picture", pictureUrl);

            if (!string.IsNullOrEmpty(link))
            {
                postDataParams.Add("link", link);
                if (!string.IsNullOrEmpty(linkName))
                    postDataParams.Add("name", linkName);
                if (!string.IsNullOrEmpty(linkCaption))
                    postDataParams.Add("caption", linkCaption);
                if (!string.IsNullOrEmpty(linkDescription))
                    postDataParams.Add("description", linkDescription);
            }

            postData = postDataParams.ToString();
        }
    }
}