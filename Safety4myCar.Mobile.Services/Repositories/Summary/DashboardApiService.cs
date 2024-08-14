using Safety4myCar.Mobile.Models;
using Safety4myCar.Mobile.Models.Dto.Summary;
using Safety4myCar.Mobile.Services.Account;

namespace Safety4myCar.Mobile.Services.Repositories.Summary
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