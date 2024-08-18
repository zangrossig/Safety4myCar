namespace Safety4myCar.Mobile.Models
{
	public class Vehicle
	{
		public required Guid Id { get; set; }

		public required string Name { get; set; }

		public required VehicleType VehicleType { get; set; }

		public required FuelType FuelType1 { get; set; }

		public required FuelType FuelType2 { get; set; } = FuelType.None;

		public string? Notes { get; set; }

		public string? Plate { get; set; }

		public int? InitialKm { get; set; }
	}

	public enum VehicleType
	{
		Car = 0,
	}
}