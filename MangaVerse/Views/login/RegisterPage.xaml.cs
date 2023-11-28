using MangaVerse.ViewModels;

namespace MangaVerse.Views
{
    public partial class RegisterPage : ContentPage
    {
        private RegisterViewModel _registerViewModel;

        public RegisterPage(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            _registerViewModel = registerViewModel;
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            string username = usernameEntry.Text;

            await _registerViewModel.RegisterAsync(email, password, username);
        }
    }
}