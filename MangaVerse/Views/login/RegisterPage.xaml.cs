namespace MangaVerse.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            ConexionFirebase conexionFirebase = new ConexionFirebase();
            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            string username = usernameEntry.Text; // Suponiendo que hay un campo para el nombre

            try
            {
                var userCredential = await conexionFirebase.CrearUsuario(email, password, username);

                await DisplayAlert("Éxito", "Registro exitoso", "OK");

                // Esperar un tiempo (opcional)
                await Task.Delay(2000);

                // Ir a la página de inicio de sesión
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_ALREADY_IN_USE"))
                {
                    await DisplayAlert("Error", "El correo electrónico ya está en uso", "OK");
                }
                else if (ex.Message.Contains("INVALID_EMAIL"))
                {
                    await DisplayAlert("Error", "Correo electrónico inválido", "OK");
                }
                else if (ex.Message.Contains("WEAK_PASSWORD"))
                {
                    await DisplayAlert("Error", "La contraseña es débil, debe tener al menos 6 caracteres", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Error desconocido al registrar usuario", "OK");
                }
            }
        }
    }
}