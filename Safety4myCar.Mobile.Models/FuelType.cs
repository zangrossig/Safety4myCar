namespace Safety4myCar.Mobile.Models
{
	public enum FuelType
	{
		None,
		Gasoline,
		Diesel,
		LPG,
		Methane,
		Other
	}

	public static class FuelTypeExtensions
	{
		public static string GetDescription(this FuelType fuelType)
		{
			var result = string.Empty;

			switch (fuelType)
			{
				case FuelType.None:
					break;

				case FuelType.Gasoline:
					result = "Benzina";
					break;

				case FuelType.Diesel:
					result = "Diesel";
					break;

				case FuelType.LPG:
					result = "GPL";
					break;

				case FuelType.Methane:
					result = "Metano";
					break;

				case FuelType.Other:
					result = "Altro";
					break;
			}

			return result;
		}
	}
}