using MangaVerse.Services;
using MangaVerse.Views;


namespace MangaVerse.ViewModels
{
    public class RegisterViewModel: BaseViewModel
    {
        private readonly IAuthService _authService;

        public RegisterViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task RegisterAsync(string email, string password, string username)
        {
            try
            {
                var userCredential = await _authService.CrearUsuario(email, password, username);

                await Application.Current.MainPage.DisplayAlert("Éxito", "Registro exitoso", "OK");

                // Ir a la página de inicio de sesión
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_ALREADY_IN_USE"))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "El correo electrónico ya está en uso", "OK");
                }
                else if (ex.Message.Contains("INVALID_EMAIL"))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Correo electrónico inválido", "OK");
                }
                else if (ex.Message.Contains("WEAK_PASSWORD"))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "La contraseña es débil, debe tener al menos 6 caracteres", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Error desconocido al registrar usuario", "OK");
                }
            }
        }
    }
}
