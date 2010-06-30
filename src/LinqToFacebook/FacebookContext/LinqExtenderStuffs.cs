using LinqToFacebook.Queries;
using LinqExtender.Configuration;

namespace LinqToFacebook
{
    public partial class FacebookContext
    {
        private void InitLinqExtender()
        {
            //Extender.Settings
            //            .For<FacebookUser>()
            //                .Begin
            //                    .Property(x => x.ID).MarkAsUnique
            //                .End
            //            .InstantiateIn(this);
            _facebookQueryFactory = new FacebookQueryFactory();
        }

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