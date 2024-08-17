namespace Safety4myCar.Mobile.Models
{
	public class Reason
	{
		public required Guid Id { get; set; }

		public required string Code { get; set; }

		public required string Description { get; set; }

		public required RegistrationType RegistrationType { get; set; }

		public bool Selectable { get; set; }
	}
}