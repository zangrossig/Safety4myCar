using Safety4myCar.Mobile.Services;
using Safety4myCar.Mobile.Services.Account;
using Safety4myCar.Mobile.Services.Navigation;

namespace Safety4myCar.Mobile.App
{
	public partial class App : Application
	{
		private readonly INavigationInterceptor interceptor;
		private readonly ILocalAccountService localAccountService;
		private readonly IConfigurationService configurationService;

		public App(INavigationInterceptor interceptor, ILocalAccountService localAccountService, IConfigurationService configurationService)
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzMzOTU0NUAzMjM2MmUzMDJlMzBoeUVPNW9kRksxbmxPNzQ2eHFCUkNyT1ZhdzRyZHlsUkd6V0F6UWVJVHFzPQ==");

			InitializeComponent();

			MainPage = new AppShell(interceptor);
			this.interceptor = interceptor;
			this.localAccountService = localAccountService;
			this.configurationService = configurationService;
		}

		protected override async void OnStart()
		{
			if (!localAccountService.IsLoaded)
			{
				await localAccountService.Load();
			}
			await configurationService.Load();

			base.OnStart();
		}
	}
}