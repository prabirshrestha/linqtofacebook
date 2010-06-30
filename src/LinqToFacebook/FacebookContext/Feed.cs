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
            string path;
            IDictionary<string, string> postData;
            ValidateWriteFeedParams(message, pictureUrl, link, linkName, linkCaption, linkDescription, out path,
                                    out postData);
            return null;
        }

        #region Helper Methods

        /// <summary>
        /// Helpers function to Validate parameters before writing the feed
        /// </summary>
        /// <remarks>
        /// This method was created seperately in order to have unit testing without hitting the fb site.
        /// </remarks>
        internal void ValidateWriteFeedParams(string message, string pictureUrl, string link, string linkName, string linkCaption, string linkDescription,
                                              out string path, out IDictionary<string, string> postData)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");

            postData = new Dictionary<string, string> { { "message", message } };

            if (!string.IsNullOrEmpty(pictureUrl))
                postData.Add("picture", pictureUrl);

            if (string.IsNullOrEmpty(link))
            {   // this means name, caption and description should also be null or empty
                if (!string.IsNullOrEmpty(linkName))
                    throw new ArgumentException("Since argument 'link' is empty, 'linkName' must also be empty",
                                                "linkName");
                if (!string.IsNullOrEmpty(linkCaption))
                    throw new ArgumentException("Since argument 'link' is empty, 'linkCaption' must also be empty",
                                                "linkCaption");
                if (!string.IsNullOrEmpty(linkDescription))
                    throw new ArgumentException("Since argument 'link' is empty, 'linkDescription' must also be empty",
                                                "linkDescription");
            }
            else
            {
                postData.Add("link", link);
                if (!string.IsNullOrEmpty(linkName))
                    postData.Add("name", linkName);
                if (!string.IsNullOrEmpty(linkCaption))
                    postData.Add("caption", linkCaption);
                if (!string.IsNullOrEmpty(linkDescription))
                    postData.Add("description", linkDescription);
            }

            AssertRequiresAccessToken();
            path = string.Format("me/feed?access_token={0}", Settings.AccessToken);
        }

        #endregion

    }
}