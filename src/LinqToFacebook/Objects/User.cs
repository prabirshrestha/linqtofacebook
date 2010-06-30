using System.Runtime.Serialization;
using LinqExtender.Interfaces;

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
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// The user's last name. (last_name)
        /// </summary>
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// The user's full name. (name)
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        /// <summary>
        /// A link to the user's profile. (link)
        /// </summary>
        [DataMember(Name = "link")]
        public string Link { get; set; }
        /// <summary>
        /// The user's blurb that appears under the profile picture. (about)
        /// </summary>
        [DataMember(Name = "about")]
        public string About { get; set; }
        /// <summary>
        /// The user's birthday. (birthday)
        /// </summary>
        [DataMember(Name = "birthday")]
        public string Birthday { get; set; }
        // todo: work,education
        /// <summary>
        /// The proxied or contact email address granted by the user. (email)
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }
        /// <summary>
        /// A link to the user's personal website. (website)
        /// </summary>
        [DataMember(Name = "website")]
        public string Website { get; set; }
        /// <summary>
        /// The user's hometown. (hometown)
        /// </summary>
        [DataMember(Name = "hometown")]
        public string HomeTown { get; set; }
        /// <summary>
        /// The user's current location. (location)
        /// </summary>
        [DataMember(Name = "location")]
        public string Location { get; set; }
        // todo: gender, interested_in, meeting_for, relationshipe_status
        /// <summary>
        /// The user's religion. (religion)
        /// </summary>
        [DataMember(Name = "religion")]
        public string Religion { get; set; }
        /// <summary>
        /// The user's political view. (political)
        /// </summary>
        [DataMember(Name = "political")]
        public string PoliticalView { get; set; }
        /// <summary>
        /// The user's account verification status (verified)
        /// </summary>
        [DataMember(Name = "verified")]
        public bool IsVerified { get; set; }
        // todo: significant_other
        /// <summary>
        /// The user's timezone. (timezone)
        /// </summary>
        [DataMember(Name = "timezone")]
        public int TimeZone { get; set; }
    }
}