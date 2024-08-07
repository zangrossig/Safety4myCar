using Safety4myCar.Mobile.ViewModels.Account;

namespace Safety4myCar.Mobile.App.Views.Account;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}