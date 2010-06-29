namespace LinqToFacebook
{
    public class FacebookSettings
    {
        public FacebookSettings()
        {
            UserAgent = "LinqToFacebook-www.prabir.me";
        }

        public string AccessToken { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string UserAgent { get; set; }
    }
}