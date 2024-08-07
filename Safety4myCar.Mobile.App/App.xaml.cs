using Safety4myCar.Mobile.Services.Navigation;

namespace Safety4myCar.Mobile.App
{
	public partial class App : Application
	{
		public App(INavigationInterceptor interceptor)
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzMzOTU0NUAzMjM2MmUzMDJlMzBoeUVPNW9kRksxbmxPNzQ2eHFCUkNyT1ZhdzRyZHlsUkd6V0F6UWVJVHFzPQ==");

			InitializeComponent();

			MainPage = new AppShell(interceptor);
		}
	}
}