using Firebase.Auth;

namespace MangaVerse.Services
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticatedAsync();
        void Login();
        void Logout();
        Task<UserCredential> CargarUsuario(string email, string password);
        Task<UserCredential> CrearUsuario(string email, string password, string username);
    }
}
