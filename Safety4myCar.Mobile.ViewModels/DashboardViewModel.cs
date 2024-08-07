using Safety4myCar.Mobile.Services.Account;
using Safety4myCar.Mobile.Services.Navigation;

namespace Safety4myCar.Mobile.ViewModels
{
	public partial class DashboardViewModel : ViewModelBase, INavigatedTo
	{
		private readonly ILocalAccountService localAccountService;
		private readonly INavigationService navigationService;
		private readonly ILoginService loginService;

		public DashboardViewModel(ILocalAccountService localAccountService, INavigationService navigationService, ILoginService loginService)
		{
			this.localAccountService = localAccountService;
			this.navigationService = navigationService;
			this.loginService = loginService;
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
	}
}