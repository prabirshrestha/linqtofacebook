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

            var postDataParams = new Dictionary<string, string> { { "message", message } };

            if (!string.IsNullOrEmpty(pictureUrl))
                postDataParams.Add("picture", pictureUrl);

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
                postDataParams.Add("link", link);
                if (!string.IsNullOrEmpty(linkName))
                    postDataParams.Add("name", linkName);
                if (!string.IsNullOrEmpty(linkCaption))
                    postDataParams.Add("caption", linkCaption);
                if (!string.IsNullOrEmpty(linkDescription))
                    postDataParams.Add("description", linkDescription);
            }

            postData = postDataParams.ToPostString();

            AssertRequiresAccessToken();
            requestUrl = string.Format("{0}{1}?access_token={2}", GraphUrl, "/me/feed", Settings.AccessToken);
        }
    }
}