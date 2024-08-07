using Safety4myCar.Mobile.Services.Account;
using Safety4myCar.Mobile.Services.Navigation;

namespace Safety4myCar.Mobile.ViewModels
{
	public partial class DashboardViewModel : ViewModelBase, INavigatedTo
	{
		private readonly ILocalAccountService localAccountService;
		private readonly INavigationService navigationService;

		public DashboardViewModel(ILocalAccountService localAccountService, INavigationService navigationService)
		{
			this.localAccountService = localAccountService;
			this.navigationService = navigationService;
		}

		public async Task OnNavigatedTo(NavigationType navigationType)
		{
			await CheckAuth();

			if (navigationType == NavigationType.Forward)
			{
			}
		}

		private async Task CheckAuth()
		{
			IsLoading = true;

			if (string.IsNullOrWhiteSpace(localAccountService.AuthToken))
			{
				if (localAccountService.Credentials != null)
				{
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
	}
}