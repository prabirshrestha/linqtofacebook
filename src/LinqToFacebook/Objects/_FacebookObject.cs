using System.Runtime.Serialization;

namespace LinqToFacebook
{
    [DataContract]
    public abstract class FacebookObject
    {
        /// <summary>
        /// Unique facebook object identifier
        /// </summary>
        [DataMember(Name = "id")]
        public string ID { get; set; }
    }
}