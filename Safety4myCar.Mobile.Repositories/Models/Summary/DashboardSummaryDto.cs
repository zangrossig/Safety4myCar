using Safety4myCar.Mobile.Repositories.Models;

namespace Safety4myCar.Mobile.Models.Dto.Summary
{
	public class DashboardSummaryDto
	{
		public Guid AutomezzoId { get; set; }
		public string? Automezzo { get; set; }
		public int NumeroRegistrazioni { get; set; }
		public decimal ImportoSpese { get; set; }
		public decimal Consumo { get; set; }
		public int Percorrenza { get; set; }
		public decimal SpesaPerKm { get; set; }
		public RiepilogoSinteticoRegistrazioni Registrazioni { get; set; } = new();
	}

	public class RiepilogoSinteticoRegistrazioni
	{
		public IEnumerable<FuelDto> Rifornimenti { get; set; } = Enumerable.Empty<FuelDto>();
		public IEnumerable<AdministrativoDto> Amministrativi { get; set; } = Enumerable.Empty<AdministrativoDto>();
		public IEnumerable<MaintenanceDto> Manutenzioni { get; set; } = Enumerable.Empty<MaintenanceDto>();
	}
}