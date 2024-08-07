namespace Safety4myCar.Mobile.Services.Navigation;

public interface INavigationParameterReceiver
{
	Task OnNavigatedTo(Dictionary<string, object>? parameters);
}