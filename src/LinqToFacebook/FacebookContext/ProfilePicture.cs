using System.Collections.Generic;

namespace LinqToFacebook
{
    public partial class FacebookContext
    {
        /// <summary>
        /// Get the url to of the current Profile Picture.
        /// </summary>
        /// <returns>Url of the facebook profile picture</returns>
        public string GetProfilePictureUrl()
        {  // todo: need unit testing for GetProfilePictureUrl()
            AssertRequiresAccessToken();
            var json = Get("me", new Dictionary<string, string>
                                     {
                                         {"fields", "id,picture"}   // some optimizations out here if we send picture only then
                                                                    // it will display id,first_name and all the user fields which are
                                                                    // not required. so putting id will get only those two fields.
                                                                    // bandwidth saved :-)
                                     });

            return json.ToJToken().Value<string>("picture");
        }
    }
}