using System.Diagnostics;

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

        public FacebookContext()
        {
            Settings = new FacebookSettings();
        }

        public FacebookContext(FacebookSettings facebookSettings)
        {
            Settings = facebookSettings;
        }

        private void AssertRequiresAccessToken()
        {
            if (string.IsNullOrEmpty(Settings.AccessToken))
                throw new AccessTokenRequiredException();
        }
    }
}