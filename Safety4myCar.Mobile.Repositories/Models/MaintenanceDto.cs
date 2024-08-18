namespace Safety4myCar.Mobile.Repositories.Models
{
	public class MaintenanceDto : RegistrationBaseDto
	{
		public string? Descrizione { get; set; }
		public MaintenanceItemDto[]? Items { get; set; }
	}

	public class MaintenanceItemDto
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid IdCausale { get; set; } = Guid.Empty;

		public decimal? Importo { get; set; }
	}
}