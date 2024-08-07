using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Safety4myCar.Mobile.App
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("fa-regular-400.ttf", "FAR");
					fonts.AddFont("fa-solid-900.ttf", "FAS");
				});

			builder.Services.RegisterMVVM();
			builder.Services.RegisterNavigation();
			builder.Services.RegisterServices();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}