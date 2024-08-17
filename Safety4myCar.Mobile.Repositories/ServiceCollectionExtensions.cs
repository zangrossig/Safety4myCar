using Microsoft.Extensions.DependencyInjection;
using Safety4myCar.Mobile.Repositories.Summary;

namespace Safety4myCar.Mobile.Repositories
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterRepositotories(this IServiceCollection services)
		{
			services.AddTransient<ILoginApiService, LoginApiService>();
			services.AddTransient<IReasonApiService, ReasonApiService>();
			services.AddTransient<IVehicleApiService, VehicleApiService>();
			services.AddTransient<IDashboardApiService, DashboardApiService>();

			return services;
		}
	}
}