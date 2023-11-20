using MangaVerse.Services;
using MangaVerse.Services.api;
using MangaVerse.Views;
using Microsoft.Extensions.Logging;
namespace MangaVerse;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("BarlowBold.otf", "Bold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddTransient<AuthService>();
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<SplashPage>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<ProfilePage>();
		builder.Services.AddTransient<DescubrePage>();
		builder.Services.AddScoped<IMangaSearch, MangaSearch>();
		builder.Services.AddScoped<IMangaTop, MangaTop>();

		return builder.Build();
	}
}
