using Safety4myCar.Mobile.Models;
using Safety4myCar.Mobile.Models.Mappers;
using Safety4myCar.Mobile.Models.Summary;
using Safety4myCar.Mobile.Services.Repositories.Summary;

namespace Safety4myCar.Mobile.Services.Summary
{
	public interface IDashboardService
	{
		Task<Result<IEnumerable<DashboardSummary>>> GetItems();
	}

	public class DashboardService : IDashboardService
	{
		private readonly IDashboardApiService service;

		public DashboardService(IDashboardApiService service)
		{
			this.service = service;
		}

		public async Task<Result<IEnumerable<DashboardSummary>>> GetItems()
		{
			var r = await service.GetItems();
			if (r.IsSuccess)
			{
				if (r.Data != null)
				{
					var summaries = DashboardMapper.Map(r.Data!);
					return Result<IEnumerable<DashboardSummary>>.Success(summaries);
				}

				return Result<IEnumerable<DashboardSummary>>.Success();
			}

			return Result<IEnumerable<DashboardSummary>>.Fail(r.ErrorCode!, r.ErrorData, r.Exception);
		}
	}
}