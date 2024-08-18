namespace Safety4myCar.Mobile.Models.Summary
{
	public class DashboardSummary
	{
		public required Vehicle Vehicle { get; set; }
		public int RegistrationsNumber { get; set; }
		public decimal Expenses { get; set; }
		public decimal Consumption { get; set; }
		public int Distance { get; set; }
		public decimal ExpensePerKm { get; set; }
		public IEnumerable<IRegistration> Registrations { get; set; } = Enumerable.Empty<IRegistration>();
	}
}