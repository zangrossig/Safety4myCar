using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Safety4myCar.Mobile.Services.Account;
using Safety4myCar.Mobile.Services.Navigation;

namespace Safety4myCar.Mobile.ViewModels.Account
{
	public partial class LoginViewModel : ViewModelBase
	{
		private readonly INavigationService navigationService;
		private readonly ILoginService loginService;

		public LoginViewModel(INavigationService navigationService, ILoginService loginService)
		{
			this.navigationService = navigationService;
			this.loginService = loginService;
		}

		[ObservableProperty]
		[NotifyCanExecuteChangedFor(nameof(TryLoginCommand))]
		private string? username;

		[ObservableProperty]
		[NotifyCanExecuteChangedFor(nameof(TryLoginCommand))]
		private string? password;

		[RelayCommand(CanExecute = nameof(CanTryLogin))]
		private async Task TryLogin()
		{
			IsLoading = true;
			var result = await loginService.TryLogin(Username!, Password!);
			if (result.IsSuccess)
			{
				Password = null;

				if (result.Data!.Value == Models.Repositories.Account.LoginResultValue.Ok)
				{
					await navigationService.GotoRoot();
				}
				else if (result.Data!.Value == Models.Repositories.Account.LoginResultValue.VerifyNeeded)
				{
				}
				else
				{
					Message = result.Data!.Message;
				}
			}
			else
			{
				Message = result.Data!.Message;
			}

			IsLoading = false;
		}

		private bool CanTryLogin() => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
	}
}