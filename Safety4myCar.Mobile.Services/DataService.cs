using Safety4myCar.Mobile.Models;
using Safety4myCar.Mobile.Models.Summary;
using Safety4myCar.Mobile.Repositories;
using Safety4myCar.Mobile.Repositories.Summary;
using Safety4myCar.Mobile.Services.Mappers;

namespace Safety4myCar.Mobile.Services
{
	public interface IDataService
	{
		Task<IEnumerable<DashboardSummary>> GetDashboardSummaries();

		Task<IEnumerable<Reason>> GetReasons();
	}

	public class DataService : IDataService
	{
		private readonly IReasonApiService reasonApiService;
		private readonly IVehicleApiService vehicleApiService;
		private readonly IDashboardApiService dashboardApiService;

		public DataService(
			IReasonApiService reasonApiService,
			IVehicleApiService vehicleApiService,
			IDashboardApiService dashboardApiService)
		{
			this.reasonApiService = reasonApiService;
			this.vehicleApiService = vehicleApiService;
			this.dashboardApiService = dashboardApiService;
		}

		private IEnumerable<Reason>? reasons = null;
		private IEnumerable<Vehicle>? vehicles = null;
		private IEnumerable<DashboardSummary>? dashboardSummaries = null;

		public async Task<IEnumerable<Reason>> GetReasons()
		{
			if (reasons == null)
			{
				var r = await reasonApiService.GetItems();
				if (r.IsSuccess && r.Data != null)
				{
					reasons = ReasonMapper.Map(r.Data!);
				}
			}

			return reasons ?? Enumerable.Empty<Reason>();
		}

		public async Task<IEnumerable<Vehicle>> GetVehicles()
		{
			if (vehicles == null)
			{
				var r = await vehicleApiService.GetItems();
				if (r.IsSuccess && r.Data != null)
				{
					vehicles = VehicleMapper.Map(r.Data!);
				}
			}

			return vehicles ?? Enumerable.Empty<Vehicle>();
		}

		public async Task<IEnumerable<DashboardSummary>> GetDashboardSummaries()
		{
			if (dashboardSummaries == null)
			{
				var r = await dashboardApiService.GetItems();
				if (r.IsSuccess && r.Data != null)
				{
					var vehicles = await GetVehicles();
					if (vehicles != null)
					{
						var list = new List<DashboardSummary>();

						foreach (var item in r.Data!)
						{
							var vehicle = vehicles.Where(x => x.Id == item.AutomezzoId).FirstOrDefault();
							if (vehicle != null)
							{
								var summary = new DashboardSummary
								{
									Vehicle = vehicle,
									Distance = item.Percorrenza,
									Consumption = item.Consumo,
									ExpensePerKm = item.SpesaPerKm,
									Expenses = item.ImportoSpese,
									RegistrationsNumber = item.NumeroRegistrazioni,
								};

								var registrations = new List<IRegistration>();
								if (item.Registrazioni.Rifornimenti.Any())
								{
									var fuels = FuelMapper.Map(item.Registrazioni.Rifornimenti);
									registrations.AddRange(fuels);
								}
								summary.Registrations = registrations.OrderByDescending(x => x.Date);

								list.Add(summary);
							}

							dashboardSummaries = list;
						}
					}
				}
			}

			return dashboardSummaries ?? Enumerable.Empty<DashboardSummary>();
		}
	}
}