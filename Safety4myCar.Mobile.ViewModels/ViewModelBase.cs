using CommunityToolkit.Mvvm.ComponentModel;

namespace Safety4myCar.Mobile.ViewModels
{
	public abstract partial class ViewModelBase : ObservableObject
	{
		protected ViewModelBase()
		{
		}

		[ObservableProperty]
		private bool isLoading;

		[ObservableProperty]
		private string? message;
	}
}