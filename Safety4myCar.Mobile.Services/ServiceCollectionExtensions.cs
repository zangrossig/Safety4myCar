using Microsoft.Extensions.DependencyInjection;
using Safety4myCar.Mobile.Services.Account;
using Safety4myCar.Mobile.Services.Repositories;

namespace Safety4myCar.Mobile.Services
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services.AddTransient<ILoginService, LoginService>();

			return services;
		}

		public static IServiceCollection RegisterRepositotories(this IServiceCollection services)
		{
			services.AddTransient<ILoginApiService, LoginApiService>();

			return services;
		}
	}
}