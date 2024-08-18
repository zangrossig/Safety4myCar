namespace Safety4myCar.Mobile.Models
{
	public class Fuel : RegistrationBase
	{
		public override RegistrationType RegistrationType => RegistrationType.Fuel;

		public FuelType FuelType { get; set; }

		public decimal? UnitPrice { get; set; }

		public bool FullTank { get; set; }

		public override string Description => FuelType.GetDescription();
	}
}