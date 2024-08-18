namespace Safety4myCar.Mobile.Repositories.Models
{
	public class FuelDto : RegistrationBaseDto
	{
		public int Carburante { get; set; }
		public decimal? ImportoUnitario { get; set; }
		public bool Pieno { get; set; }
	}
}