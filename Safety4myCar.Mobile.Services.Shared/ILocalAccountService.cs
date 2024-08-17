using Safety4myCar.Mobile.Models.Account;

namespace Safety4myCar.Mobile.Services.Shared
{
	public interface ILocalAccountService
	{
		LocalCredentials? Credentials { get; set; }
		string? AuthToken { get; set; }

		bool IsLoaded { get; }

		void Clear();

		Task Load();

		Task Save();
	}
}