using LinqToFacebook.Queries;

namespace LinqToFacebook
{
    public partial class FacebookContext
    {
        private FacebookQueryFactory _facebookQueryFactory;
        
        private FacebookUserQuery _facebookUserQuery;
        public FacebookUserQuery Users
        {
            get
            {
                return _facebookUserQuery ?? (_facebookUserQuery = new FacebookUserQuery(Settings));
            }
        }

    }
}