using System;
using MangaVerse.Services;
using Firebase.Auth;

namespace MangaVerse.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthService _authService;

        public LoginPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            ConexionFirebase conexionFirebase = new ConexionFirebase();
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            try
            {
                var credenciales = await conexionFirebase.CargarUsuario(email, password);
                var uid = credenciales.User.Uid;

                await DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");

                _authService.Login();
                var splashPage = new SplashPage(_authService);

                // Mostrar la SplashPage
                await Navigation.PushAsync(splashPage);
                await Task.Delay(2000);
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("INVALID_EMAIL"))
                {
                    await DisplayAlert("Error", "Correo electrónico inválido", "OK");
                }
                else if (ex.Message.Contains("USER_NOT_FOUND") || ex.Message.Contains("WRONG_PASSWORD"))
                {
                    await DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Error desconocido al iniciar sesión", "OK");
                }
            }
        }
    }
}
