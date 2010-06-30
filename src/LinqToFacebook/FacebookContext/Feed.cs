using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LinqToFacebook
{
    public partial class FacebookContext
    {
        public string WriteFeed(string message, string link, string name, string caption, string description)
        {
            AssertRequiresAccessToken();
            return null;
        }

        public string WriteToWall(string message, string link, string name, string caption, string description)
        {
            return WriteFeed(message, link, name, caption, description);
        }
    }
}