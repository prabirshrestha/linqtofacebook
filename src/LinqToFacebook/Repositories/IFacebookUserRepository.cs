using LinqExtender.Interfaces;

namespace LinqToFacebook.Repositories
{
    public interface IFacebookUserRepository
    {
        FacebookUser GetFacebookUser(IBucket bucket);
    }

    public class FacebookUserRepository : IFacebookUserRepository
    {
        private readonly FacebookSettings _facebookSettings;

        public FacebookUserRepository(FacebookSettings facebookSettings)
        {
            _facebookSettings = facebookSettings;
        }

        #region Implementation of IFacebookUserRepository

        public FacebookUser GetFacebookUser(IBucket bucket)
        {
            var facebookContext = new FacebookContext(_facebookSettings);
            return facebookContext.Get<FacebookUser>(bucket.Items[FacebookObject.KeyId].Value.ToString(), null);
        }

        #endregion
    }
}