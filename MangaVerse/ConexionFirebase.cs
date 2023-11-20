using Firebase.Auth;
using Firebase.Auth.Providers;

namespace MangaVerse
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

        public async Task<UserCredential> CargarUsuario(string Email, string Password)
        {
            var cliente = ConectarFirebase();
            var userCredential = await cliente.SignInWithEmailAndPasswordAsync(Email, Password);

            return userCredential;
        }

        public async Task<UserCredential> CrearUsuario(string Email, string Password, string Username)
        {
            var cliente = ConectarFirebase();
            var userCredential = await cliente.CreateUserWithEmailAndPasswordAsync(Email, Password, Username);
            return userCredential;
        }
        public static async Task<UserCredential> CargarUsuarioLogin(string email, string password)
        {
            var cliente = ConectarFirebase();
            var userCredential = await cliente.SignInWithEmailAndPasswordAsync(email, password);
            return userCredential; // Retorna el UserCredential después de un inicio de sesión exitoso

        }
        // public static async Task<UserCredential> CargarUsuario(string email, string password, ProfileViewModel viewModel)
        // {
        //     var cliente = ConectarFirebase();

        //     try
        //     {
        //         var userCredential = await cliente.SignInWithEmailAndPasswordAsync(email, password);
        //         var usuario = userCredential?.User;

        //         if (usuario != null)
        //         {
        //             string username = usuario.ChangeDisplayNameAsync; // Obtener el nombre de usuario
        //             viewModel.Username = username; // Asignar el nombre de usuario al ViewModel
        //         }

        //         return userCredential; // Retornar el UserCredential después de un inicio de sesión exitoso
        //     }
        //     catch (FirebaseAuthException ex)
        //     {
        //         // Manejo de errores en el inicio de sesión
        //         throw; // Puedes lanzar o manejar esta excepción según tu flujo de la aplicación
        //     }
        // }
    }
}
