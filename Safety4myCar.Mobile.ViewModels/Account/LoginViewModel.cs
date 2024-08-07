using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Safety4myCar.Mobile.ViewModels.Account
{
	public partial class LoginViewModel : ViewModelBase
	{
		public LoginViewModel()
		{
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
		}

		private bool CanTryLogin() => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
	}
}