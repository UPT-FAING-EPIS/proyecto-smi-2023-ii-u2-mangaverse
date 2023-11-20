using MangaVerse.Services;
namespace MangaVerse.Views
{
    public partial class ProfilePage: ContentPage
    {
        private ProfileViewModel viewModel;

        private readonly AuthService _authService;
        public ProfilePage(AuthService authService)
        {
            InitializeComponent();
             _authService = authService;
             viewModel = new ProfileViewModel();
             BindingContext = viewModel;
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            _authService.Logout();

            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}