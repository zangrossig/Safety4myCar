using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Safety4myCar.Mobile.Repositories;
using Safety4myCar.Mobile.Services;
using Syncfusion.Maui.Core.Hosting;

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
				.ConfigureSyncfusionCore()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("fa-regular-400.ttf", "FAR");
					fonts.AddFont("fa-solid-900.ttf", "FAS");
				});

			builder.Services.RegisterMVVM();
			builder.Services.RegisterNavigation();
			builder.Services.RegisterInternalServices();
			builder.Services.RegisterServices();
			builder.Services.RegisterRepositotories();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}