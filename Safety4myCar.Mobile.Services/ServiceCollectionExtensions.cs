using Microsoft.Extensions.DependencyInjection;
using Safety4myCar.Mobile.Services.Account;
using Safety4myCar.Mobile.Services.Repositories;
using Safety4myCar.Mobile.Services.Repositories.Summary;
using Safety4myCar.Mobile.Services.Summary;

namespace Safety4myCar.Mobile.Services
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services.AddTransient<ILoginService, LoginService>();
			services.AddTransient<IDashboardService, DashboardService>();

			return services;
		}

		public static IServiceCollection RegisterRepositotories(this IServiceCollection services)
		{
			services.AddTransient<ILoginApiService, LoginApiService>();
			services.AddTransient<IDashboardApiService, DashboardApiService>();

			return services;
		}
	}
}