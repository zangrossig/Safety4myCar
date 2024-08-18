namespace Safety4myCar.Mobile.Repositories.Models
{
	public abstract class RegistrationBaseDto
	{
		public Guid Id { get; set; }

		public int Tipo { get; set; }

		public Guid IdAutomezzo { get; set; }

		public DateTime Data { get; set; }

		public int? Km { get; set; }

		public decimal? Importo { get; set; }

		public string? Note { get; set; }
	}
}