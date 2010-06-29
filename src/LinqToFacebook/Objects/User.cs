namespace LinqToFacebook
{
    /// <summary>
    /// A facebook user profile.
    /// </summary>
    /// <remarks>
    /// http://developers.facebook.com/docs/reference/api/user
    /// </remarks>
    public class FacebookUser : FacebookObject
    {
        /// <summary>
        /// The user's first name. (first_name)
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The user's last name. (last_name)
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The user's full name. (name)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A link to the user's profile. (link)
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// The user's blurb that appears under the profile picture. (about)
        /// </summary>
        public string About { get; set; }
        /// <summary>
        /// The user's birthday. (birthday)
        /// </summary>
        public string Birthday { get; set; }
        // todo: work,education
        /// <summary>
        /// The proxied or contact email address granted by the user. (email)
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// A link to the user's personal website. (website)
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// The user's hometown. (hometown)
        /// </summary>
        public string HomeTown { get; set; }
        /// <summary>
        /// The user's current location. (location)
        /// </summary>
        public string Location { get; set; }
        // todo: gender, interested_in, meeting_for, relationshipe_status
        /// <summary>
        /// The user's religion. (religion)
        /// </summary>
        public string Religion { get; set; }
        /// <summary>
        /// The user's political view. (political)
        /// </summary>
        public string PoliticalView { get; set; }
        /// <summary>
        /// The user's account verification status (verified)
        /// </summary>
        public bool IsVerified { get; set; }
        // todo: significant_other
        /// <summary>
        /// The user's timezone. (timezone)
        /// </summary>
        public int TimeZone { get; set; }
    }
}