using System.Runtime.Serialization;
using LinqExtender.Attributes;

namespace LinqToFacebook
{
    [DataContract]
    public abstract class FacebookObject
    {
        /// <summary>
        /// Unique facebook object identifier
        /// </summary>
        [DataMember(Name = "id")]
        [UniqueIdentifier]
        public string ID { get; set; }

        internal const string KeyId = "ID";
    }
}