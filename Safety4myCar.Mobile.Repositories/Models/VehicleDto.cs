namespace Safety4myCar.Mobile.Repositories.Models
{
	public class VehicleDto
	{
		public Guid Id { get; set; }

		public string? Descrizione { get; set; }

		public int Tipo { get; set; }

		public int Carburante1 { get; set; }

		public int Carburante2 { get; set; }

		public string? Note { get; set; }

		public string? Targa { get; set; }

		public int? KmIniziali { get; set; }
	}
}