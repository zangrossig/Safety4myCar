using Safety4myCar.Mobile.Models;
using Safety4myCar.Mobile.Repositories.Models;

namespace Safety4myCar.Mobile.Services.Mappers
{
	public static class VehicleMapper
	{
		public static IEnumerable<Vehicle> Map(IEnumerable<VehicleDto> items)
		{
			return items.Select(dto =>
				new Vehicle
				{
					Id = dto.Id,
					Name = dto.Descrizione!,
					VehicleType = VehicleType.Car,
					Fuel1 = GetFuel(dto.Carburante1),
					Fuel2 = GetFuel(dto.Carburante2),
					Plate = dto.Targa,
					InitialKm = dto.KmIniziali,
					Notes = dto.Note
				});
		}

		public static Vehicle Map(VehicleDto dto)
		{
			return new Vehicle
			{
				Id = dto.Id,
				Name = dto.Descrizione!,
				VehicleType = VehicleType.Car,
				Fuel1 = GetFuel(dto.Carburante1),
				Fuel2 = GetFuel(dto.Carburante2),
				Plate = dto.Targa,
				InitialKm = dto.KmIniziali,
				Notes = dto.Note
			};
		}

		private static Fuel GetFuel(int fuelDto)
		{
			var result = Fuel.Other;

			switch (fuelDto)
			{
				case -100:
					result = Fuel.None;
					break;

				case -1:
					result = Fuel.Other;
					break;

				case 0:
					result = Fuel.Gasoline;
					break;

				case 10:
					result = Fuel.Diesel;
					break;

				case 20:
					result = Fuel.LPG;
					break;

				case 30:
					result = Fuel.Methane;
					break;
			}

			return result;
		}
	}
}