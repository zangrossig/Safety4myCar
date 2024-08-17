using Safety4myCar.Mobile.Models.Dto.Summary;
using Safety4myCar.Mobile.Repositories.Models;
using Safety4myCar.Mobile.Services.Shared;

namespace Safety4myCar.Mobile.Repositories.Summary
{
	public interface IDashboardApiService
	{
		Task<Result<IEnumerable<DashboardSummaryDto>>> GetItems();
	}

	public class DashboardApiService : ApiGateway, IDashboardApiService
	{
		public DashboardApiService(IConfigurationService configurationService, ILocalAccountService localAccountService) : base(configurationService, localAccountService)
		{
		}

		public async Task<Result<IEnumerable<DashboardSummaryDto>>> GetItems()
		{
			var result = await Get<IEnumerable<DashboardSummaryDto>>("Riepiloghi/Sintesi");

			return result;
		}
	}
}