namespace Safety4myCar.Mobile.Services.Navigation;

public interface INavigatedFrom
{
	Task OnNavigatedFrom(NavigationType navigationType);
}
