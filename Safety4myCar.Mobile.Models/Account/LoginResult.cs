namespace Safety4myCar.Mobile.Models.Account
{
	public class LoginResult
	{
		public LoginResultValue Value { get; set; }

		public string? AuthToken { get; set; }

		public string? Message { get; set; }
	}
}