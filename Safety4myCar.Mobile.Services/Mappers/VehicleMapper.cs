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
					FuelType1 = GetFuel(dto.Carburante1),
					FuelType2 = GetFuel(dto.Carburante2),
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
				FuelType1 = GetFuel(dto.Carburante1),
				FuelType2 = GetFuel(dto.Carburante2),
				Plate = dto.Targa,
				InitialKm = dto.KmIniziali,
				Notes = dto.Note
			};
		}

		private static FuelType GetFuel(int fuelDto)
		{
			var result = FuelType.Other;

			switch (fuelDto)
			{
				case -100:
					result = FuelType.None;
					break;

				case -1:
					result = FuelType.Other;
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