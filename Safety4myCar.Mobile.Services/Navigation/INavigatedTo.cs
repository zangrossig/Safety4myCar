namespace Safety4myCar.Mobile.Services.Navigation;

public interface INavigatedTo
{
	Task OnNavigatedTo(NavigationType navigationType);
}
