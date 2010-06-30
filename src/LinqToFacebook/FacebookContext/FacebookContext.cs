using System.Collections.Generic;
using System.Diagnostics;
using LinqToFacebook.Queries;

namespace LinqToFacebook
{
    public partial class FacebookContext
    {
        private FacebookSettings _facebookSettings;
        public FacebookSettings Settings
        {
            [DebuggerStepThrough]
            get
            {   // this assures that Facebook Settings is never null.
                return _facebookSettings ?? (_facebookSettings = new FacebookSettings());
            }
            [DebuggerStepThrough]
            set { _facebookSettings = value; }
        }

        private const string GraphUrl = "https://graph.facebook.com/{0}";

        public FacebookContext()
            : this(new FacebookSettings())
        {
        }

        public FacebookContext(FacebookSettings facebookSettings)
        {
            Settings = facebookSettings;
            _facebookQueryFactory = new FacebookQueryFactory();
        }

        #region Helpers

        private void AssertRequiresAccessToken()
        {
            if (string.IsNullOrEmpty(Settings.AccessToken))
                throw new AccessTokenRequiredException();
        }

        private void AddAccessTokenIfRequriedTo(IDictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(Settings.AccessToken))
                return;

            if (parameters == null)
                parameters = new Dictionary<string, string>();

            if (!parameters.ContainsKey("access_token"))
                parameters.Add("access_token", Settings.AccessToken);
        }

        #endregion

    }
}