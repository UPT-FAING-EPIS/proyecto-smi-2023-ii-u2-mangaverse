using MangaVerse.Services;
using MangaVerse.Views;

namespace MangaVerse.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task LoginAsync(string email, string password)
        {
            try
            {
                var credenciales = await _authService.CargarUsuario(email, password);
                var uid = credenciales.User.Uid;

                await Application.Current.MainPage.DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");

                _authService.Login();
                var splashPage = new SplashPage(_authService);

                // Mostrar la SplashPage
                await Application.Current.MainPage.Navigation.PushAsync(splashPage);
                await Task.Delay(2000);
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("INVALID_EMAIL"))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Correo electrónico inválido", "OK");
                }
                else if (ex.Message.Contains("USER_NOT_FOUND") || ex.Message.Contains("WRONG_PASSWORD"))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Error desconocido al iniciar sesión", "OK");
                }
            }
        }
    }
}
