using Safety4myCar.Mobile.Repositories.Models;
using Safety4myCar.Mobile.Services.Shared;

namespace Safety4myCar.Mobile.Repositories
{
	public interface IVehicleApiService
	{
		Task<Result<IEnumerable<VehicleDto>>> GetItems();
	}

	public class VehicleApiService : ApiGateway, IVehicleApiService
	{
		public VehicleApiService(IConfigurationService configurationService, ILocalAccountService localAccountService) : base(configurationService, localAccountService)
		{
		}

		public async Task<Result<IEnumerable<VehicleDto>>> GetItems()
		{
			var result = await Get<IEnumerable<VehicleDto>>("Automezzi");

			return result;
		}
	}
}