namespace Safety4myCar.Mobile.Services.Navigation
{
	public interface INavigationInterceptor
	{
		Task OnNavigatedTo(object bindingContext, NavigationType navigationType);

		Task<bool> CanNavigate(object bindingContext, NavigationType type);
	}
}