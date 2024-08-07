using Safety4myCar.Mobile.ViewModels;

namespace Safety4myCar.Mobile.App.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}