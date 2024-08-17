namespace Safety4myCar.Mobile.Repositories.Models
{
	public class ReasonDto
	{
		public Guid Id { get; set; }

		public string? Codice { get; set; }

		public string? Descrizione { get; set; }

		public int Tipo { get; set; }

		public bool Selezionabile { get; set; }
	}
}