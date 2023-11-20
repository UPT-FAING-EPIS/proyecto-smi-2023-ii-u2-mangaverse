using MangaVerse.Services;

namespace MangaVerse.Views
{
    public partial class SplashPage: ContentPage
    {
        private readonly AuthService _authService;
        public SplashPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }
        protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if(await _authService.IsAuthenticatedAsync())
        {
            // User is logged in
            // redirect to main page
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
