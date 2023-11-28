using MangaVerse.Services;
namespace MangaVerse.Views
{
    public partial class ProfilePage: ContentPage
    {
        private ProfileViewModel viewModel;

        private readonly IAuthService _authService;
        public ProfilePage(IAuthService authService)
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