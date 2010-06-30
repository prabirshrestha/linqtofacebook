using LinqExtender;
using System;
using LinqToFacebook.Repositories;

namespace LinqToFacebook.Queries
{
    public class FacebookUserQuery : Query<FacebookUser>
    {
        private readonly IFacebookUserRepository _facebookUserRepository;
        private readonly FacebookSettings _facebookSettings;

        public FacebookUserQuery(FacebookSettings facebookSettings)
        {
            _facebookSettings = facebookSettings ?? new FacebookSettings();
            _facebookUserRepository = new FacebookUserRepository(_facebookSettings);
        }

        protected override FacebookUser GetItem(LinqExtender.Interfaces.IBucket bucket)
        {
            if (bucket.Items[FacebookObject.KeyId].Value == null)
            {
                throw new NullReferenceException("Query must contain the unique facebook user id.");
            }

            return _facebookUserRepository.GetFacebookUser(bucket);

        }
    }
}