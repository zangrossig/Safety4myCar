using Microsoft.Extensions.DependencyInjection;
using Safety4myCar.Mobile.Services.Account;

namespace Safety4myCar.Mobile.Services
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services.AddTransient<ILoginService, LoginService>();
			services.AddSingleton<IDataService, DataService>();

			return services;
		}
	}
}