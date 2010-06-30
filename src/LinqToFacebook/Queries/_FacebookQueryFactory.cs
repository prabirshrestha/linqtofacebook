namespace LinqToFacebook.Queries
{
    internal class FacebookQueryFactory
    {
        public FacebookUserQuery CreateFacebookUserQuery(FacebookSettings facebookSettings)
        {
            return new FacebookUserQuery(facebookSettings);
        }
    }
}