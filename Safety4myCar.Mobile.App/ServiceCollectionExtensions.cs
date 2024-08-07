using CommunityToolkit.Maui;
using Safety4myCar.Mobile.App.Views;
using Safety4myCar.Mobile.App.Views.Account;
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
	}
}