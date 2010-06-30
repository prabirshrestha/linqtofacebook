using System.Runtime.Serialization;

namespace LinqToFacebook
{
    /// <summary>
    /// An individual entry in a profile's feed
    /// </summary>
    /// <remarks>
    /// http://developers.facebook.com/docs/reference/api/post
    /// </remarks>
    [DataContract]
    public class FacebookPost : FacebookObject
    {
        /// <summary>
        /// An object containing the ID and name of the user who posted the message. [from]
        /// </summary>
        [DataMember(Name = "from")]
        public string From { get; set; }

        // todo: to

        /// <summary>
        /// The message. [message]
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// If available, a link to the picture included with this post. [picture]
        /// </summary>
        [DataMember(Name = "picture")]
        public string Picture { get; set; }

        /// <summary>
        /// The link attached to this post. [link]
        /// </summary>
        [DataMember(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// The name of the link. [name]
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The caption of the link (appears beneath the link name). [caption]
        /// </summary>
        [DataMember(Name = "caption")]
        public string Caption { get; set; }

        /// <summary>
        /// A description of the link (appears beneath the link caption). [description]
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// If available, the source link attached to this post (for example, a flash or video file). [source]
        /// </summary>
        [DataMember(Name = "source")]
        public string Source { get; set; }

        /// <summary>
        /// A link to an icon representing the type of this post. [icon]
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// A string indicating which application was used to create this post. [attribution]
        /// </summary>
        [DataMember(Name = "attribution")]
        public string Attribution { get; set; }

        // todo: actions

        /// <summary>
        /// The number of likes on this post. [likes]
        /// </summary>
        [DataMember(Name = "likes")]
        public string Likes { get; set; }

        /// <summary>
        /// The time the post was initially published. [created_time]
        /// </summary>
        [DataMember(Name = "created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// The time of the last comment on this post. [updated_time]
        /// </summary>
        [DataMember(Name = "updated_time")]
        public string UpdatedTime { get; set; }
    }
}