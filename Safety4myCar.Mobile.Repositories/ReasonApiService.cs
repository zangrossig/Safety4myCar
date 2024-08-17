using Safety4myCar.Mobile.Repositories.Models;
using Safety4myCar.Mobile.Services.Shared;

namespace Safety4myCar.Mobile.Repositories
{
	public interface IReasonApiService
	{
		Task<Result<IEnumerable<ReasonDto>>> GetItems();
	}

	public class ReasonApiService : ApiGateway, IReasonApiService
	{
		public ReasonApiService(IConfigurationService configurationService, ILocalAccountService localAccountService) : base(configurationService, localAccountService)
		{
		}

		public async Task<Result<IEnumerable<ReasonDto>>> GetItems()
		{
			var result = await Get<IEnumerable<ReasonDto>>("Causali");

			return result;
		}
	}
}