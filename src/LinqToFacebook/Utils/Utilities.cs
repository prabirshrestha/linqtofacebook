using System;
using Newtonsoft.Json;

namespace LinqToFacebook.Utilities
{
    public static class FacebookUtilities
    {
        #region Json Serializers/Deserializers

        public static string SerializeToJsonObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeJsonObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        #endregion


        #region Xml Serializers/Deserializers

        public static string SerializeToXml<T>(T obj)
        {   // most likely won't be implemented any time soon
            throw new NotImplementedException();
        }

        public static T DeserializeXmlObject<T>(string jsonString)
        {   // most likely won't be implemented any time soon
            throw new NotImplementedException();
        }

        #endregion

    }
}