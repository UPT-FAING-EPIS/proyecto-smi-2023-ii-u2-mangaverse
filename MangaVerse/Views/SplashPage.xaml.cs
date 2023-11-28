using MangaVerse.Services;

namespace MangaVerse.Views
{
    public partial class SplashPage : ContentPage
    {
        private readonly IAuthService _authService;

        public SplashPage(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (await _authService.IsAuthenticatedAsync())
            {
                // User is logged in
                // Redirect to main page
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                // User is not logged in 
                // Redirect to LoginPage
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }
    }
}
