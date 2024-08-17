using CommunityToolkit.Mvvm.ComponentModel;
using Safety4myCar.Mobile.Models.Summary;
using Safety4myCar.Mobile.Services;
using Safety4myCar.Mobile.Services.Account;
using Safety4myCar.Mobile.Services.Navigation;
using Safety4myCar.Mobile.Services.Shared;

namespace Safety4myCar.Mobile.ViewModels
{
	public partial class DashboardViewModel : ViewModelBase, INavigatedTo
	{
		private readonly ILocalAccountService localAccountService;
		private readonly INavigationService navigationService;
		private readonly ILoginService loginService;
		private readonly IDataService dataService;

		public DashboardViewModel(ILocalAccountService localAccountService, INavigationService navigationService, ILoginService loginService, IDataService dataService)
		{
			this.localAccountService = localAccountService;
			this.navigationService = navigationService;
			this.loginService = loginService;
			this.dataService = dataService;
		}

		[ObservableProperty]
		private IEnumerable<DashboardSummary>? summaries;

		public async Task OnNavigatedTo(NavigationType navigationType)
		{
			await CheckAuth();
			await LoadData();
		}

		private async Task CheckAuth()
		{
			IsLoading = true;

			if (string.IsNullOrWhiteSpace(localAccountService.AuthToken))
			{
				if (!localAccountService.IsLoaded)
				{
					await localAccountService.Load();
				}

				if (localAccountService.Credentials != null)
				{
					await loginService.TrySilentLogin();
				}
				else
				{
					await navigationService.GotoLogin();
				}
			}

			if (string.IsNullOrWhiteSpace(localAccountService.AuthToken))
			{
				await navigationService.GotoLogin();
			}

			IsLoading = false;
		}

		private async Task LoadData()
		{
			IsLoading = true;

			Summaries = await dataService.GetDashboardSummaries();

			IsLoading = false;
		}
	}
}