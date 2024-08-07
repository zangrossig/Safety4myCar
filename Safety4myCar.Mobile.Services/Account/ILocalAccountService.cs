using Safety4myCar.Mobile.Models.Account;

namespace Safety4myCar.Mobile.Services.Account
{
	public interface ILocalAccountService
	{
		LocalCredentials? Credentials { get; set; }
		string? AuthToken { get; set; }

		void Clear();

		Task Load();

		Task Save();
	}
}