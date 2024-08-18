using Safety4myCar.Mobile.Models;
using Safety4myCar.Mobile.Repositories.Models;

namespace Safety4myCar.Mobile.Services.Mappers
{
	public static class FuelMapper
	{
		public static IEnumerable<Fuel> Map(IEnumerable<FuelDto> items)
		{
			return items.Select(x => new Fuel
			{
				Id = x.Id,
				Date = DateOnly.FromDateTime(x.Data),
				Distance = x.Km,
				Expense = x.Importo,
				FuelType = MapFuel(x.Carburante),
				FullTank = x.Pieno,
				Notes = x.Note,
				UnitPrice = x.ImportoUnitario,
				VehicleId = x.IdAutomezzo,
			});
		}

		private static FuelType MapFuel(int fuelTypeDto)
		{
			var result = FuelType.Other;

			switch (fuelTypeDto)
			{
				case -100:
					result = FuelType.None;
					break;

				case 0:
					result = FuelType.Gasoline;
					break;

				case 10:
					result = FuelType.Diesel;
					break;

				case 20:
					result = FuelType.LPG;
					break;

				case 30:
					result = FuelType.Methane;
					break;
			}

			return result;
		}
	}
}