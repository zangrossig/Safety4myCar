namespace Safety4myCar.Mobile.App
{
	public partial class App : Application
	{
		public App()
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzMzOTU0NUAzMjM2MmUzMDJlMzBoeUVPNW9kRksxbmxPNzQ2eHFCUkNyT1ZhdzRyZHlsUkd6V0F6UWVJVHFzPQ==");

			InitializeComponent();

			MainPage = new AppShell();
		}
	}
}