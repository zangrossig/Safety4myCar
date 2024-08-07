using CommunityToolkit.Maui;
using Safety4myCar.Mobile.App.Services;
using Safety4myCar.Mobile.App.Services.Account;
using Safety4myCar.Mobile.App.Services.Navigation;
using Safety4myCar.Mobile.App.Views;
using Safety4myCar.Mobile.App.Views.Account;
using Safety4myCar.Mobile.Services;
using Safety4myCar.Mobile.Services.Account;
using Safety4myCar.Mobile.Services.Navigation;
using Safety4myCar.Mobile.ViewModels;
using Safety4myCar.Mobile.ViewModels.Account;

namespace Safety4myCar.Mobile.App
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterMVVM(this IServiceCollection services)
		{
			services.AddTransientWithShellRoute<DashboardPage, DashboardViewModel>(Routes.Dashboard);
			services.AddTransientWithShellRoute<LoginPage, LoginViewModel>(Routes.AccountLogin);

			return services;
		}

		public static IServiceCollection RegisterNavigation(this IServiceCollection services)
		{
			services.AddSingleton<NavigationService>();

			services.AddSingleton<INavigationService>(c => c.GetRequiredService<NavigationService>());

			services.AddSingleton<INavigationInterceptor>(c => c.GetRequiredService<NavigationService>());

			return services;
		}

		public static IServiceCollection RegisterInternalServices(this IServiceCollection services)
		{
			services.AddSingleton<IDialogService, DialogService>();
			services.AddSingleton<ILocalAccountService, LocalAccountService>();
			services.AddSingleton<IConfigurationService, ConfigurationService>();

			return services;
		}
	}
}