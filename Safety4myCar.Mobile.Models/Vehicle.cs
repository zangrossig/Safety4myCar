namespace Safety4myCar.Mobile.Models
{
	public class Vehicle
	{
		public required Guid Id { get; set; }

		public required string Name { get; set; }

		public required VehicleType VehicleType { get; set; }

		public required Fuel Fuel1 { get; set; }

		public required Fuel Fuel2 { get; set; } = Fuel.None;

		public string? Notes { get; set; }

		public string? Plate { get; set; }

		public int? InitialKm { get; set; }
	}

	public enum VehicleType
	{
		Car = 0,
	}
}