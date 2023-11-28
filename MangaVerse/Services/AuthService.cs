using Firebase.Auth;

namespace MangaVerse.Services
{
    public class AuthService : IAuthService
    {
        private const string AuthStateKey = "AuthState";

        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(2000);
            var authState = Preferences.Default.Get<bool>(AuthStateKey, false);
            return authState;
        }

        public void Login()
        {
            Preferences.Default.Set<bool>(AuthStateKey, true);
        }

        public void Logout()
        {
            Preferences.Default.Remove(AuthStateKey);
        }

        public async Task<UserCredential> CargarUsuario(string email, string password)
        {
            var cliente = ConexionFirebase.ConectarFirebase();
            var userCredential = await cliente.SignInWithEmailAndPasswordAsync(email, password);
            return userCredential;
        }

        public async Task<UserCredential> CrearUsuario(string email, string password, string username)
        {
            var cliente = ConexionFirebase.ConectarFirebase();
            var userCredential = await cliente.CreateUserWithEmailAndPasswordAsync(email, password, username);
            return userCredential;
        }
    }
}
