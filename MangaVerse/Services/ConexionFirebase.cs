using Firebase.Auth;
using Firebase.Auth.Providers;

namespace MangaVerse.Services
{
    public class ConexionFirebase
    {
        public static FirebaseAuthClient ConectarFirebase()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyAdlhiayzbzLJcl8YWHDTUkiFYIdPgqc64",
                AuthDomain = "mangaverse-c5e33.web.app",
                Providers = new FirebaseAuthProvider[]
                {
                    // Add and configure individual providers
                    new GoogleProvider().AddScopes("email"),
                    new EmailProvider()
                    // ...
                },
            };

            var client = new FirebaseAuthClient(config);
            return client;
        }
    }
}
