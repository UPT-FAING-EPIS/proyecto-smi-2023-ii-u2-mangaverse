using MangaVerse.Services;
using MangaVerse.ViewModels;

namespace MangaVerse.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _viewModel;
        private readonly IAuthService _authService;

        public LoginPage(LoginViewModel viewModel, IAuthService authService)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _authService = authService;
            BindingContext = _viewModel;
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var registerViewModel = new RegisterViewModel(_authService);
            await Navigation.PushAsync(new RegisterPage(registerViewModel));
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            await _viewModel.LoginAsync(email, password);

        }
    }
}
