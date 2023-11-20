using MangaVerse.Views;

namespace MangaVerse;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(HomePage),typeof(HomePage));
		Routing.RegisterRoute(nameof(SplashPage),typeof(SplashPage));
		Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
		Routing.RegisterRoute(nameof(ProfilePage),typeof(ProfilePage));
		Routing.RegisterRoute(nameof(RegisterPage),typeof(RegisterPage));
	}
}
