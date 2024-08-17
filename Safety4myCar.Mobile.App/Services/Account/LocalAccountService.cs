using Safety4myCar.Mobile.Models.Account;
using Safety4myCar.Mobile.Services.Shared;
using System.Text.Json;

namespace Safety4myCar.Mobile.App.Services.Account
{
	public class LocalAccountService : ILocalAccountService
	{
		public LocalAccountService()
		{
		}

		private const string CredentialsKey = "Credentials";

		public LocalCredentials? Credentials { get; set; }

		public string? AuthToken { get; set; }

		public bool IsLoaded { get; private set; }

		public async Task Load()
		{
			Credentials = null;
			AuthToken = null;

			var s = await SecureStorage.Default.GetAsync(CredentialsKey);
			if (!string.IsNullOrWhiteSpace(s))
			{
				Credentials = JsonSerializer.Deserialize<LocalCredentials>(s);
			}

			IsLoaded = true;
		}

		public async Task Save()
		{
			if (Credentials != null)
			{
				var s = JsonSerializer.Serialize(Credentials!);
				await SecureStorage.Default.SetAsync(CredentialsKey, s);
			}
			else
			{
				Clear();
			}
		}

		public void Clear()
		{
			SecureStorage.Default.Remove(CredentialsKey);
			AuthToken = null;
		}
	}
}