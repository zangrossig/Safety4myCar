namespace Safety4myCar.Mobile.Models
{
	public interface IRegistration
	{
		RegistrationType RegistrationType { get; }
		decimal? Expense { get; set; }
		string Description { get; }
		DateOnly Date { get; set; }
	}

	public abstract class RegistrationBase : IRegistration
	{
		public required Guid Id { get; set; }

		public required Guid VehicleId { get; set; }

		public abstract RegistrationType RegistrationType { get; }

		public required DateOnly Date { get; set; }

		public int? Distance { get; set; }

		public decimal? Expense { get; set; }

		public string? Notes { get; set; }

		public abstract string Description { get; }
	}
}