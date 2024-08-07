using Safety4myCar.Mobile.Models.Configuration;
using Safety4myCar.Mobile.Services;
using System.Text.Json;

namespace Safety4myCar.Mobile.App.Services
{
	public class ConfigurationService : IConfigurationService
	{
		private const string ConfigurationKey = "Configuration";

		public ConfigurationData Data { get; private set; } = new();

		public void Clear()
		{
			Data = new();

			SecureStorage.Default.Remove(ConfigurationKey);
		}

		public async Task Load()
		{
			Data = new();

			var s = await SecureStorage.Default.GetAsync(ConfigurationKey);
			if (!string.IsNullOrWhiteSpace(s))
			{
				var data = JsonSerializer.Deserialize<ConfigurationData>(s);
				if (data != null)
				{
					Data = data!;
				}
			}
		}

		public async Task Save()
		{
			var s = JsonSerializer.Serialize(Data!);
			await SecureStorage.Default.SetAsync(ConfigurationKey, s);
		}
	}
}