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
	}
}